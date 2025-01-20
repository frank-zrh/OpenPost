using OpenPostLib.Core;
using OpenPostForms.dialogs;
using OpenPostLib.Environment;
using Microsoft.VisualBasic.Logging;
using OpenPostLib.Log;
using static OpenPostLib.Core.Req;

namespace OpenPostForms
{
    public partial class FormMain : Form
    {
        private RegInfo regInfo = new RegInfo();
        private Solution solution = new Solution();
        private string solutionFilePath = string.Empty;
        private Project selectedProject;
        private Group selectedGroup;
        private RequestInfo selectedRequest;

        private bool viewDeletedItems = false;
        private bool dataInitialzing = false;

        private RequestInfo objectInCopy;

        public FormMain()
        {
            dataInitialzing = true;
            objectInCopy = null;
            InitializeComponent();
            var profilepath = EnvTool.GetDefaultProfilePath();
            if (File.Exists(profilepath))
            {
                try
                {
                    regInfo = RegInfo.LoadFromFile(profilepath);
                    if (!string.IsNullOrEmpty(regInfo.SelectedSolutionFile) && File.Exists(regInfo.SelectedSolutionFile))
                    {
                        solutionFilePath = regInfo.SelectedSolutionFile;
                        solution = solution.ImportFromFile(solutionFilePath);

                        if (!string.IsNullOrEmpty(regInfo.SelectedProjectId))
                        {
                            if (Guid.TryParse(regInfo.SelectedProjectId, out Guid projectId))
                            {
                                selectedProject = solution.Projects.FirstOrDefault(p => p.Id == projectId);
                            }
                            if (!string.IsNullOrEmpty(regInfo.SelectedGroupId))
                            {
                                if (Guid.TryParse(regInfo.SelectedGroupId, out Guid groupId))
                                {
                                    selectedGroup = selectedProject?.Groups.FirstOrDefault(g => g.Id == groupId);
                                }
                                if (!string.IsNullOrEmpty(regInfo.SelectedRequestId))
                                {
                                    if (Guid.TryParse(regInfo.SelectedRequestId, out Guid requestId))
                                    {
                                        selectedRequest = selectedGroup?.HttpRequests.FirstOrDefault(r => r.Id == requestId);
                                        LoadSelectedRequestInfo();
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LLog.LogException(ex);

                }

                if (solution.Projects.Count == 0)
                {
                    solution.GenerateSampleData();
                }

                DisplayProjectsInTreeView(solution.Projects);
                if (selectedRequest == null)
                {
                    ToggleControlsEnabledStatus(tabControlHttpRequest.Controls, false);
                }
                InitializeListView(listViewRequestHeader);
                InitializeListView(listViewRequestParameter);
                HideRequestBodyControls();
            }
            else
            {
                
                solution.GenerateSampleData();
                DisplayProjectsInTreeView(solution.Projects);
                ToggleControlsEnabledStatus(tabControlHttpRequest.Controls, false);
                InitializeListView(listViewRequestHeader);
                InitializeListView(listViewRequestParameter);
                HideRequestBodyControls();
            }
            dataInitialzing = false;
        }

        private void LoadSelectedRequestInfo()
        {
            labelRequestPath.Text = $"{selectedProject?.Name} => {selectedGroup?.Name} => {selectedRequest?.Name}";
           
            foreach (TreeNode projectNode in treeViewProjects.Nodes)
            {
                if (projectNode.Tag == selectedProject)
                {
                    treeViewProjects.SelectedNode = projectNode;
                    break;
                }
            }
            ToggleControlsEnabledStatus(tabControlHttpRequest.Controls, true);
            LoadHttpRequestInfoToControls(selectedRequest);
            LoadRequestHistoryToTreeView(selectedRequest);
           
            var respdetails = GetLastQueryResponse(selectedRequest);
            if (respdetails != null)
            {
                DisplayResponseInTreeView(respdetails, treeViewResponse);
            }
            UpdateURLAfterParamsChanged();
        }

        private void InitializeListView(ListView listView)
        {
            listView.View = View.Details;
            listView.FullRowSelect = true;
            listView.Columns.Add("Key", 300);

            listView.Columns.Add("Value", listView.Width - listView.Columns[0].Width - 5);

        }


        private void SaveSolutionFile(bool saveas)
        {
            if (string.IsNullOrEmpty(solutionFilePath) || saveas == true)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "JSON files (*.json)|*.json",
                    Title = "Save solution to file"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    solutionFilePath = saveFileDialog.FileName;
                    solution.ExportToFile(solutionFilePath);
                    regInfo.SelectedSolutionFile = solutionFilePath;
                }
            }
            else
            {
                solution.ExportToFile(solutionFilePath);
            }

        }


        private void LoadSolutionFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                Title = "Open solution from file"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                solutionFilePath = openFileDialog.FileName;
                solution = solution.ImportFromFile(solutionFilePath);
                DisplayProjectsInTreeView(solution.Projects);
                regInfo.SelectedSolutionFile = solutionFilePath;
            }
        }

        public void ToggleControlsEnabledStatus(dynamic controls, bool enabled)
        {
            foreach (Control control in controls)
            {
                control.Enabled = enabled;
            }
        }

        public void DisplayProjectsInTreeView(List<Project> projects)
        {
            treeViewProjects.Nodes.Clear();

            foreach (var project in projects)
            {
                if (project.status == DeletedStastus.Deleted && viewDeletedItems == false)
                {
                    continue;
                }

                TreeNode projectNode = new TreeNode(project.Name)
                {
                    Tag = project,
                    ContextMenuStrip = contextMenuStripProject
                };

                foreach (var group in project.Groups)
                {
                    if (group.status == DeletedStastus.Deleted && viewDeletedItems == false)
                    {
                        continue;
                    }

                    TreeNode groupNode = new TreeNode(group.Name)
                    {
                        Tag = group,
                        ContextMenuStrip = contextMenuStripGroup
                    };

                    foreach (var request in group.HttpRequests)
                    {
                        if (request.status == DeletedStastus.Deleted && viewDeletedItems == false)
                        {
                            continue;
                        }

                        TreeNode requestNode = new TreeNode(request.Name)
                        {
                            Tag = request,
                            ContextMenuStrip = contextMenuStripHttpRequestInfo
                        };


                        if (request.status == DeletedStastus.Deleted)
                        {
                            requestNode.ForeColor = Color.DarkGray;
                        }
                        else
                        {
                            bool lastQueryStatus = GetLastQueryResponseStatus(request);
                            if (lastQueryStatus == false)
                            {
                                requestNode.ForeColor = Color.Red;
                            }
                            else
                            {
                                requestNode.ForeColor = Color.Black;
                            }
                        }

                        groupNode.Nodes.Add(requestNode);

                    }


                    if (group.status == DeletedStastus.Deleted)
                    {
                        groupNode.ForeColor = Color.DarkGray;
                    }

                    projectNode.Nodes.Add(groupNode);
                }


                if (project.status == DeletedStastus.Deleted)
                {
                    projectNode.ForeColor = Color.DarkGray;
                }

                treeViewProjects.Nodes.Add(projectNode);
            }

            treeViewProjects.ExpandAll();
        }


        private void treeViewProjects_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node != null)
            {
                dataInitialzing = true;
                ClearHttpRequestInfoControls();
                ClearHttpResponseInfoControls();
                HideRestoreMenuItems();
                var selectedNode = e.Node;
                if (selectedNode.Tag is Project project)
                {
                    selectedProject = project;
                    labelRequestPath.Text = project.Name;
                    ToggleControlsEnabledStatus(tabControlHttpRequest.Controls, false);
                    if (selectedProject.status == DeletedStastus.Deleted)
                    {
                        toolStripMenuItemRestoreProject.Visible = true;
                        toolStripMenuItemClearProject.Visible = true;
                        deleteProjectToolStripMenuItem.Visible = false;
                    }
                    else
                    {
                        toolStripMenuItemRestoreProject.Visible = false;
                        toolStripMenuItemClearProject.Visible = false;
                        deleteProjectToolStripMenuItem.Visible = true;
                    }
                }
                else if (selectedNode.Tag is Group group)
                {
                    selectedGroup = group;
                    selectedProject = selectedNode.Parent.Tag as Project;
                    var projectNode = selectedNode.Parent;
                    if (projectNode != null && projectNode.Tag is Project parentProject)
                    {
                        labelRequestPath.Text = $"{parentProject.Name} => {group.Name}";
                        ToggleControlsEnabledStatus(tabControlHttpRequest.Controls, false);
                    }
                    if (selectedGroup.status == DeletedStastus.Deleted)
                    {
                        toolStripMenuItemRestoreGroup.Visible = true;
                        toolStripMenuItemClearGroup.Visible = true;
                        deleteGroupToolStripMenuItem.Visible = false;
                    }
                    else
                    {
                        toolStripMenuItemRestoreGroup.Visible = false;
                        toolStripMenuItemClearGroup.Visible = false;
                        deleteGroupToolStripMenuItem.Visible = true;
                    }
                }
                else if (selectedNode.Tag is RequestInfo request)
                {
                    selectedRequest = request;
                    selectedGroup = selectedNode.Parent.Tag as Group;
                    selectedProject = selectedNode.Parent.Parent.Tag as Project;
                    var groupNode = selectedNode.Parent;
                    if (groupNode != null && groupNode.Tag is Group parentGroup)
                    {
                        var projectNode = groupNode.Parent;
                        if (projectNode != null && projectNode.Tag is Project parentProject)
                        {
                            labelRequestPath.Text = $"{parentProject.Name} => {parentGroup.Name} => {request.Name}";
                            ToggleControlsEnabledStatus(tabControlHttpRequest.Controls, true);
                            if (selectedRequest.RequestParameters == null)
                            {
                                buttonRequestQuery.Enabled = false;
                                buttonRequestSave.Enabled = false;
                            }
                            LoadHttpRequestInfoToControls(request);
                            LoadRequestHistoryToTreeView(request);
                            var respdetails = GetLastQueryResponse(request);
                            if (respdetails != null)
                            {
                                DisplayResponseInTreeView(respdetails, treeViewResponse);
                            }
                        }
                    }
                    if (selectedRequest.status == DeletedStastus.Deleted)
                    {
                        toolStripMenuItemRestoreRequest.Visible = true;
                        toolStripMenuItemClearRequest.Visible = true;
                        deleteToolStripMenuItem.Visible = false;
                    }
                    else
                    {
                        toolStripMenuItemRestoreRequest.Visible = false;
                        toolStripMenuItemClearRequest.Visible = false;
                        deleteToolStripMenuItem.Visible = true;
                    }
                    ToggleControlsEnabledStatus(tabControlHttpRequest.Controls, true);
                    UpdateURLAfterParamsChanged();
                }
                else
                {
                    ToggleControlsEnabledStatus(tabControlHttpRequest.Controls, false);
                }

                dataInitialzing = false;
            }
        }

        private void openToolStripMenuItemOpenProject_Click(object sender, EventArgs e)
        {
            LoadSolutionFile();
        }

        private void saveToolStripMenuItemSaveProject_Click(object sender, EventArgs e)
        {
            SaveSolutionFile(false);
        }

        private void saveAsToolStripMenuItemSaveasProject_Click(object sender, EventArgs e)
        {
            SaveSolutionFile(true);
        }

        private void openToolStripMenuItemNewProject_Click(object sender, EventArgs e)
        {
            solutionFilePath = string.Empty;
            solution = new Solution();
            solution.Projects = new List<Project>();
            solution.Projects.Add(new Project
            {
                Name = "Default",
                Description = "Default Project Description",
                Order = 1
            });
            DisplayProjectsInTreeView(solution.Projects);
        }


        private void LoadHttpRequestInfoToControls(RequestInfo request)
        {
            if (request == null) return;

            textBoxRequestName.Text = request.Name ?? string.Empty;
            textBoxRequestDescription.Text = request.Description ?? string.Empty;

            if (request.RequestParameters != null)
            {
                textBoxRequestURL.Text = request.RequestParameters.Url ?? string.Empty;
                comboBoxRequestMethod.SelectedItem = request.RequestParameters.Method?.ToString() ?? string.Empty;

                listViewRequestHeader.Items.Clear();
                if (request.RequestParameters.Headers != null)
                {
                    foreach (var header in request.RequestParameters.Headers)
                    {
                        listViewRequestHeader.Items.Add(new ListViewItem(new string[] { header.Key, header.Value }));
                    }
                }

                listViewRequestParameter.Items.Clear();
                if (request.RequestParameters.QueryParameters != null)
                {
                    foreach (var queryParameter in request.RequestParameters.QueryParameters)
                    {
                        listViewRequestParameter.Items.Add(new ListViewItem(new string[] { queryParameter.Key, queryParameter.Value }));
                    }
                }


                var contentType = Req.GetContentTypeEnum(request.RequestParameters.ContentType);
                switch (contentType)
                {
                    case ContentTypeEnum.Json:
                    case ContentTypeEnum.Xml:
                    case ContentTypeEnum.Html:
                    case ContentTypeEnum.JavaScript:
                    case ContentTypeEnum.Text:
                        radioButtonBodyRaw.Checked = true;
                        SetRichTextBoxRequestBodyForRaw();
                        richTextBoxRequestBody.Text = request.RequestParameters.Body ?? string.Empty;
                        comboBoxRqeuestBodyDataType.SelectedItem = contentType.ToString();
                        break;
                    case ContentTypeEnum.FormData:
                        radioButtonBodyFormData.Checked = true;
                        SetDataGridViewRequestBodyForFormData(false);
                        dataGridViewRequestBody.Rows.Clear();
                        foreach (var item in request.RequestParameters.FormData)
                        {
                            dataGridViewRequestBody.Rows.Add(item.Key, item.Type == FormDataItemType.String ? "Text" : "File", item.Value);
                        }
                        break;
                    case ContentTypeEnum.UrlEncoded:
                        radioButtonBodyFormurlencoded.Checked = true;
                        SetDataGridViewRequestBodyForFormData(true);
                        dataGridViewRequestBody.Rows.Clear();
                        foreach (var kvp in request.RequestParameters.UrlEncodedData)
                        {
                            dataGridViewRequestBody.Rows.Add(kvp.Key, kvp.Value);
                        }
                        break;
                    case ContentTypeEnum.Binary:
                        radioButtonBodyBinary.Checked = true;
                        HideRequestBodyControls();
                        labelBodyBinaryFile.Visible = true;
                        labelBodyBinaryFile.Text = Path.GetFileName(request.RequestParameters.FilePath);
                        labelBodyBinaryFileFull.Text = request.RequestParameters.FilePath;
                        break;
                    case ContentTypeEnum.None:
                    default:
                        radioButtonBodyNone.Checked = true;
                        HideRequestBodyControls();
                        break;
                }
            }
        }




        private void ClearHttpRequestInfoControls()
        {
            textBoxRequestName.Text = string.Empty;
            textBoxRequestDescription.Text = string.Empty;
            textBoxRequestURL.Text = string.Empty;
            comboBoxRequestMethod.SelectedIndex = 0;

            radioButtonBodyNone.Checked = true;

            richTextBoxRequestBody.Text = string.Empty;

            dataGridViewRequestBody.Rows.Clear();

            listViewRequestHeader.Items.Clear();
            listViewRequestParameter.Items.Clear();
            listViewQueryHistory.Items.Clear();

            radioButtonBodyNone.Checked = true;
            HideRequestBodyControls();

        }


        private void ClearHttpResponseInfoControls()
        {
            treeViewResponse.Nodes.Clear();
            richTextBoxResponseBodyInText.Text = string.Empty;
            richTextBoxResponseBodyInHex.Text = string.Empty;
            tabControlResponseBodyView.SelectedTab = tabPageResponseOverview;
        }


        private void toolStripMenuItemSetProjectName_Click(object sender, EventArgs e)
        {
            if (selectedProject != null && !string.IsNullOrEmpty(toolStripTextBoxProjectName.Text))
            {
                selectedProject.Name = toolStripTextBoxProjectName.Text;


                foreach (TreeNode node in treeViewProjects.Nodes)
                {
                    if (node.Tag == selectedProject)
                    {
                        node.Text = selectedProject.Name;
                        break;
                    }
                }

                if (solutionFilePath != string.Empty && string.IsNullOrEmpty(solutionFilePath))
                {
                    solution.ExportToFile(solutionFilePath);
                }
                else
                {
                    //prompt to create the solution file
                    SaveSolutionFile(true);
                }

            }
        }

        private void toolStripMenuItemSaveGroupName_Click(object sender, EventArgs e)
        {

            if (selectedGroup != null && !string.IsNullOrEmpty(toolStripTextBoxGroupName.Text))
            {
                selectedGroup.Name = toolStripTextBoxGroupName.Text;

                foreach (TreeNode node in treeViewProjects.Nodes)
                {
                    foreach (TreeNode childNode in node.Nodes)
                    {
                        if (childNode.Tag == selectedGroup)
                        {
                            childNode.Text = selectedGroup.Name;
                            break;
                        }
                    }
                }
                if (solutionFilePath != string.Empty)
                {

                    solution.ExportToFile(solutionFilePath);
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormNewItem formNewGroup = new FormNewItem())
            {
                formNewGroup.ItemType = FormItemType.Group;
                formNewGroup.SetTitle("New Group");
                formNewGroup.ShowDialog();
                if (formNewGroup.NewItem != null)
                {
                    if (selectedProject != null)
                    {
                        selectedProject.Groups.Add((Group)formNewGroup.NewItem);
                        DisplayProjectsInTreeView(solution.Projects);
                        if (solutionFilePath != string.Empty)
                        {
                            solution.ExportToFile(solutionFilePath);
                        }
                    }
                }
            }
        }

        private void newRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormNewItem formNewGroup = new FormNewItem())
            {
                formNewGroup.ItemType = FormItemType.Request;
                formNewGroup.SetTitle("New Request");
                formNewGroup.ShowDialog();
                if (formNewGroup.NewItem != null)
                {
                    if (selectedGroup != null)
                    {
                        selectedGroup.HttpRequests.Add((RequestInfo)formNewGroup.NewItem);
                        DisplayProjectsInTreeView(solution.Projects);

                        //set the new request as the selected request
                        foreach (TreeNode projectNode in treeViewProjects.Nodes)
                        {
                            foreach (TreeNode groupNode in projectNode.Nodes)
                            {
                                foreach (TreeNode requestNode in groupNode.Nodes)
                                {
                                    if (requestNode.Tag == formNewGroup.NewItem)
                                    {
                                        treeViewProjects.SelectedNode = requestNode;
                                        selectedRequest = (RequestInfo)formNewGroup.NewItem;
                                        LoadSelectedRequestInfo();
                                        break;
                                    }
                                }
                            }
                        }

                        if (solutionFilePath != string.Empty)
                        {
                            solution.ExportToFile(solutionFilePath);
                        }

                    }
                }
            }
        }

        private void toolStripMenuItemNewProject_Click(object sender, EventArgs e)
        {
            using (FormNewItem formNewGroup = new FormNewItem())
            {
                formNewGroup.ItemType = FormItemType.Project;
                formNewGroup.SetTitle("New Project");
                formNewGroup.ShowDialog();
                if (formNewGroup.NewItem != null)
                {
                    solution.Projects.Add((Project)formNewGroup.NewItem);
                    DisplayProjectsInTreeView(solution.Projects);
                    if (solutionFilePath != string.Empty)
                    {
                        solution.ExportToFile(solutionFilePath);
                    }
                }
            }
        }

        private void buttonRequestSave_Click(object sender, EventArgs e)
        {
            if (comboBoxRequestMethod.SelectedItem == null || string.IsNullOrEmpty(textBoxRequestURL.Text))
            {
                MessageBox.Show("Error:invalid http request parameters.");
                return;
            }
            SaveRequest();
            DisplayProjectsInTreeView(solution.Projects);
        }

        private void SaveRequest()
        {
            if (selectedRequest != null)
            {
                HttpMethod method = HttpMethod.Get;
                if (comboBoxRequestMethod.SelectedItem != null)
                {
                    method = comboBoxRequestMethod.SelectedItem.ToString() switch
                    {
                        "GET" => HttpMethod.Get,
                        "POST" => HttpMethod.Post,
                        "PUT" => HttpMethod.Put,
                        "DELETE" => HttpMethod.Delete,
                        "HEAD" => HttpMethod.Head,
                        "OPTIONS" => HttpMethod.Options,
                        "PATCH" => HttpMethod.Patch,
                        "TRACE" => HttpMethod.Trace,
                        _ => throw new InvalidOperationException("Invalid HTTP method selected.")
                    };
                }

                selectedRequest.Name = textBoxRequestName.Text;
                selectedRequest.Description = textBoxRequestDescription.Text;
                if (selectedRequest.RequestParameters == null)
                {
                    selectedRequest.RequestParameters = new Req(method, textBoxRequestURL.Text);
                }
                selectedRequest.RequestParameters.Url = textBoxRequestURL.Text;
                selectedRequest.RequestParameters.SetContentType(GetContentType());
                AddRequestBodyDetails(selectedRequest.RequestParameters);

                if (comboBoxRequestMethod.SelectedItem != null)
                {
                    selectedRequest.RequestParameters.Method = method;
                }

                selectedRequest.RequestParameters.Body = richTextBoxRequestBody.Text;
                selectedRequest.RequestParameters.Headers = new Dictionary<string, string>();
                foreach (ListViewItem item in listViewRequestHeader.Items)
                {
                    selectedRequest.RequestParameters.Headers.Add(item.SubItems[0].Text, item.SubItems[1].Text);
                }
                selectedRequest.RequestParameters.QueryParameters = new Dictionary<string, string>();
                foreach (ListViewItem item in listViewRequestParameter.Items)
                {
                    selectedRequest.RequestParameters.QueryParameters.Add(item.SubItems[0].Text, item.SubItems[1].Text);
                }
                if (solutionFilePath != string.Empty)
                {
                    solution.ExportToFile(solutionFilePath);
                }

                LoadSelectedRequestInfo();
            }

            if (selectedRequest?.RequestParameters != null)
            {
                buttonRequestQuery.Enabled = true;
            }
            else
            {
                buttonRequestQuery.Enabled = false;
            }
        }

        private void AddRequestBodyDetails(Req req)
        {
            if (req != null)
            {
                var contentType = GetContentType();

                if (contentType == ContentTypeEnum.None)
                {
                    return;
                }
                else if (contentType == ContentTypeEnum.Json || contentType == ContentTypeEnum.Xml || contentType == ContentTypeEnum.Html || contentType == ContentTypeEnum.JavaScript || contentType == ContentTypeEnum.Text)
                {
                    req.Body = richTextBoxRequestBody.Text;
                }
                else if (contentType == ContentTypeEnum.FormData)
                {
                    req.FormData.Clear();
                    foreach (DataGridViewRow row in dataGridViewRequestBody.Rows)
                    {
                        if (row.Cells[0].Value != null && row.Cells[1].Value != null && row.Cells[2].Value != null)
                        {
                            var item = new FormDataItem
                            {
                                Key = row.Cells[0].Value.ToString(),
                                Type = row.Cells[1].Value.ToString().ToLower() == "text" ? FormDataItemType.String : FormDataItemType.File,
                                Value = row.Cells[2].Value.ToString()
                            };
                            req.FormData.Add(item);
                        }
                    }


                }
                else if (contentType == ContentTypeEnum.UrlEncoded)
                {
                    foreach (DataGridViewRow row in dataGridViewRequestBody.Rows)
                    {
                        if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                        {
                            req.UrlEncodedData.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                        }
                    }
                }
                else if (contentType == ContentTypeEnum.Binary)
                {
                    req.FilePath = labelBodyBinaryFileFull.Text;

                }
            }
        }

        private ContentTypeEnum GetContentType()
        {
            if (radioButtonBodyRaw.Checked)
            {
                //Json
                //Text
                //HTML
                //XML
                //Javascript
                if (comboBoxRqeuestBodyDataType.SelectedItem?.ToString() == "Html")
                {
                    return ContentTypeEnum.Html;
                }
                else if (comboBoxRqeuestBodyDataType.SelectedItem?.ToString() == "Xml")
                {
                    return ContentTypeEnum.Xml;
                }
                else if (comboBoxRqeuestBodyDataType.SelectedItem?.ToString() == "Text")
                {
                    return ContentTypeEnum.Text;
                }
                else if (comboBoxRqeuestBodyDataType.SelectedItem?.ToString() == "JavaScript")
                {
                    return ContentTypeEnum.JavaScript;
                }
                else
                {
                    return ContentTypeEnum.Json;
                }
            }
            else if (radioButtonBodyFormData.Checked)
            {
                return ContentTypeEnum.FormData;
            }
            else if (radioButtonBodyFormurlencoded.Checked)
            {
                return ContentTypeEnum.UrlEncoded;
            }
            else if (radioButtonBodyBinary.Checked)
            {
                return ContentTypeEnum.Binary;
            }
            else
            {
                return ContentTypeEnum.None;
            }
        }

        private void buttonNewHeaderAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxNewHeaderKey.Text) && !string.IsNullOrEmpty(textBoxNewHeaderValue.Text))
            {
                listViewRequestHeader.Items.Add(new ListViewItem(new string[] { textBoxNewHeaderKey.Text, textBoxNewHeaderValue.Text }));
                textBoxNewHeaderKey.Text = string.Empty;
                textBoxNewHeaderValue.Text = string.Empty;
            }
        }

        private void buttonNewParamAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxNewParamKey.Text) && !string.IsNullOrEmpty(textBoxNewParamValue.Text))
            {
                listViewRequestParameter.Items.Add(new ListViewItem(new string[] { textBoxNewParamKey.Text, textBoxNewParamValue.Text }));
                textBoxNewParamKey.Text = string.Empty;
                textBoxNewParamValue.Text = string.Empty;
                UpdateURLAfterParamsChanged();
            }
        }

        private async void buttonRequestQuery_Click(object sender, EventArgs e)
        {
            if (selectedRequest != null)
            {
                SaveRequest();
                DisableQueryControls();
                
                try
                {
                    var response = await ExecuteQueryAsync(selectedRequest.RequestParameters);
                    if (response != null)
                    {
                        DisplayResponseInTreeView(RespDetails.FromHttpResponseMessage(response), treeViewResponse);
                        EnvTool.SaveRequestHistory(selectedRequest.Id, RespDetails.FromHttpResponseMessage(response));
                        LoadRequestHistoryToTreeView(selectedRequest);

                        foreach (TreeNode projectNode in treeViewProjects.Nodes)
                        {
                            foreach (TreeNode groupNode in projectNode.Nodes)
                            {
                                foreach (TreeNode requestNode in groupNode.Nodes)
                                {
                                    if (requestNode.Tag == selectedRequest)
                                    {
                                        requestNode.ForeColor = GetLastQueryResponseStatus(selectedRequest) ? Color.DarkGreen : Color.Red;
                                        break;
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Error: query failed, check the parameters and try again.");
                    }
                }
                catch (Exception ex)
                {
                    LLog.LogException(ex);
                    MessageBox.Show("Query Failed: " + ex.Message);
                }
                finally
                {
                    EnableQueryControls();                    
                }
            }
        }

        private async Task<Resp> ExecuteQueryAsync(Req req)
        {
            return await Query.ExecuteAsync(req);
        }

        private void DisableQueryControls()
        {
            buttonRequestQuery.Enabled = false;
            buttonRequestSave.Enabled = false;
            buttonNewHeaderAdd.Enabled = false;
            buttonNewParamAdd.Enabled = false;
        }

        private void EnableQueryControls()
        {
            buttonRequestQuery.Enabled = true;
            buttonRequestSave.Enabled = true;
            buttonNewHeaderAdd.Enabled = true;
            buttonNewParamAdd.Enabled = true;
        }


        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (solutionFilePath != string.Empty && File.Exists(solutionFilePath))
            {
                regInfo.SelectedSolutionFile = solutionFilePath;
                if (selectedProject != null)
                {
                    regInfo.SelectedProjectId = selectedProject.Id.ToString();
                }
                if (selectedGroup != null)
                {
                    regInfo.SelectedGroupId = selectedGroup.Id.ToString();
                }
                if (selectedRequest != null)
                {
                    regInfo.SelectedRequestId = selectedRequest.Id.ToString();
                }
                regInfo.SaveToFile(EnvTool.GetDefaultProfilePath());
            }
        }

        private void DisplayResponseInTreeView(RespDetails response, TreeView view)
        {
            if (response != null)
            {

                view.Nodes.Clear();

                TreeNode statusCodeNode = new TreeNode($"Status Code: {(int)response.StatusCode}")
                {
                    Tag = response.StatusCode
                };
                view.Nodes.Add(statusCodeNode);

                TreeNode reasonPhraseNode = new TreeNode($"Reason Phrase: {response.ReasonPhrase}")
                {
                    Tag = response.ReasonPhrase
                };
                view.Nodes.Add(reasonPhraseNode);

                TreeNode headersNode = new TreeNode("Headers")
                {
                    Tag = response.Headers
                };
                foreach (var header in response.Headers)
                {
                    TreeNode headerNode = new TreeNode($"{header.Key}: {string.Join(", ", header.Value)}");
                    headersNode.Nodes.Add(headerNode);
                }
                view.Nodes.Add(headersNode);

                TreeNode contentHeadersNode = new TreeNode("Content Headers")
                {
                    Tag = response.ContentHeaders
                };
                foreach (var header in response.ContentHeaders)
                {
                    TreeNode headerNode = new TreeNode($"{header.Key}: {string.Join(", ", header.Value)}");
                    contentHeadersNode.Nodes.Add(headerNode);
                }
                view.Nodes.Add(contentHeadersNode);

                string content = response.Content;

                TreeNode contentNode = new TreeNode($"Content: {content}")
                {
                    Tag = content
                };
                view.Nodes.Add(contentNode);
                view.ExpandAll();

                richTextBoxResponseBodyInText.Text = content;

            }
        }

        private bool GetLastQueryResponseStatus(RequestInfo req)
        {
            var response = GetLastQueryResponse(req);
            if (response != null)
            {
                //return true if the status code is in the range of 200-299
                return (int)response.StatusCode >= 200 && (int)response.StatusCode < 300;
            }

            return true;
        }

        private RespDetails GetLastQueryResponse(RequestInfo req)
        {

            var history = EnvTool.GetRequestHistory(req.Id);
            if (history != null && history.Count > 0)
            {
                var selectedDate = history[0];
                var response = EnvTool.LoadRequestHistory<RespDetails>(req.Id, selectedDate);
                if (response != null)
                {
                    return response;
                }
            }

            return null;
        }

        private void LoadRequestHistoryToTreeView(RequestInfo req)
        {
            if (req == null)
            {
                LLog.LogError("Request is null");
                return;
            }

            var history = EnvTool.GetRequestHistory(req.Id);
            if (history != null)
            {

                listViewQueryHistory.Items.Clear();


                listViewQueryHistory.Columns[0].Width = listViewQueryHistory.Width - 5;


                foreach (var item in history)
                {
                    listViewQueryHistory.Items.Add(new ListViewItem(new string[] { item.ToString("yyyy-MM-dd HH:mm:ss") }));
                }




            }
        }

        private void listViewQueryHistory_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listViewQueryHistory.SelectedItems.Count > 0)
            {
                var selectedDate = DateTime.Parse(listViewQueryHistory.SelectedItems[0].Text);
                var response = EnvTool.LoadRequestHistory<RespDetails>(selectedRequest.Id, selectedDate);
                DisplayResponseInTreeView(response, treeViewResponse);
            }
        }

        private async void tabControlResponseBodyView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlResponseBodyView.SelectedTab == tabPageResponseBodyInHTML)
            {

                await webView2ResponseBodyInHTML.EnsureCoreWebView2Async(null);


                var content = richTextBoxResponseBodyInText.Text.Trim('"');
                if (Uri.IsWellFormedUriString(content, UriKind.Absolute))
                {
                    var uri = new Uri(content);
                    var imageExtensions = new[] { ".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tiff", ".svg" };
                    if (imageExtensions.Any(ext => uri.AbsolutePath.EndsWith(ext, StringComparison.OrdinalIgnoreCase)))
                    {
                        using (HttpClient client = new HttpClient())
                        {
                            try
                            {
                                var imageBytes = await client.GetByteArrayAsync(uri);
                                var base64String = Convert.ToBase64String(imageBytes);
                                var imageSrc = $"data:image/{uri.AbsolutePath.Split('.').Last()};base64,{base64String}";
                                var htmlContent = $"<img src='{imageSrc}' />";
                                webView2ResponseBodyInHTML.NavigateToString(htmlContent);
                            }
                            catch (Exception ex)
                            {

                                LLog.LogException(ex);
                            }
                        }
                    }
                    else
                    {

                        webView2ResponseBodyInHTML.Source = uri;
                    }
                }
                else
                {

                    webView2ResponseBodyInHTML.NavigateToString(richTextBoxResponseBodyInText.Text);
                }
            }
            else if (tabControlResponseBodyView.SelectedTab == tabPageResponseBodyInHex)
            {
                richTextBoxResponseBodyInHex.Text = EnvTool.ToHex(richTextBoxResponseBodyInText.Text);
            }
        }

        private void textBoxRequestURL_TextChanged(object sender, EventArgs e)
        {
            if (Uri.IsWellFormedUriString(textBoxRequestURL.Text, UriKind.Absolute))
            {
                textBoxRequestURL.BackColor = Color.FromArgb(249, 255, 249);
                buttonRequestSave.Enabled = true;
            }
            else
            {
                textBoxRequestURL.BackColor = Color.FromArgb(255, 249, 249);
                buttonRequestSave.Enabled = false;
            }
        }

        private void deleteProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //message box to confirm the deletion
            var result = MessageBox.Show($"Are you sure you want to delete the project {selectedProject.Name}?", "Delete Project", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DeleteProject(selectedProject);
            }



        }

        private void DeleteProject(Project todel, bool force = false)
        {
            if (todel != null)
            {
                if (force == false)
                {
                    selectedProject.status = DeletedStastus.Deleted;

                    foreach (var group in selectedProject.Groups)
                    {
                        group.status = DeletedStastus.Deleted;
                        foreach (var request in group.HttpRequests)
                        {
                            request.status = DeletedStastus.Deleted;
                        }
                    }
                }
                else
                {
                    solution.Projects.Remove(todel);
                }

                DisplayProjectsInTreeView(solution.Projects);
                if (solutionFilePath != string.Empty)
                {
                    solution.ExportToFile(solutionFilePath);
                }
            }
        }

        private void DeleteGroup(Group todel, bool force = false)
        {
            if (todel != null)
            {

                if (force == false)
                {
                    selectedGroup.status = DeletedStastus.Deleted;

                    foreach (var request in selectedGroup.HttpRequests)
                    {
                        request.status = DeletedStastus.Deleted;
                    }
                }
                else
                {
                    selectedProject.Groups.Remove(todel);
                }
                DisplayProjectsInTreeView(solution.Projects);
                if (solutionFilePath != string.Empty)
                {
                    solution.ExportToFile(solutionFilePath);
                }

            }
        }

        private void DeleteRequest(RequestInfo todel, bool force = false)
        {
            if (todel != null)
            {
                if (force == false)
                {
                    selectedRequest.status = DeletedStastus.Deleted;
                }
                else
                {
                    selectedGroup.HttpRequests.Remove(todel);
                }
                DisplayProjectsInTreeView(solution.Projects);
                if (solutionFilePath != string.Empty)
                {
                    solution.ExportToFile(solutionFilePath);
                }
            }
        }

        private void deleteGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show($"Are you sure you want to delete the group {selectedGroup.Name}?", "Delete Group", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DeleteGroup(selectedGroup);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show($"Are you sure you want to delete the request {selectedRequest.Name}?", "Delete Request", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DeleteRequest(selectedRequest);
            }
        }

        private void toolStripMenuItemViewAll_Click(object sender, EventArgs e)
        {
            if (viewDeletedItems == true)
            {
                viewDeletedItems = false;
                toolStripMenuItemViewAll.Text = "View All Items";
                toolStripMenuItemClearDeleted.Visible = false;
            }
            else
            {
                viewDeletedItems = true;
                toolStripMenuItemViewAll.Text = "View Active Items";
                toolStripMenuItemClearDeleted.Visible = true;
            }

            DisplayProjectsInTreeView(solution.Projects);

        }

        private void toolStripMenuItemClearDeleted_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("Are you sure you want to clear all the deleted items?", "Clear Deleted Items", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }


            solution.Projects.RemoveAll(p => p.status == DeletedStastus.Deleted);
            foreach (var project in solution.Projects)
            {
                project.Groups.RemoveAll(g => g.status == DeletedStastus.Deleted);
                foreach (var group in project.Groups)
                {
                    group.HttpRequests.RemoveAll(r => r.status == DeletedStastus.Deleted);
                }
            }
            DisplayProjectsInTreeView(solution.Projects);
        }

        private void toolStripMenuItemRestoreRequest_Click(object sender, EventArgs e)
        {
            if (selectedRequest != null && selectedRequest.status == DeletedStastus.Deleted)
            {

                var result = MessageBox.Show($"Are you sure you want to restore the request {selectedRequest.Name}?", "Restore Request", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    selectedRequest.status = DeletedStastus.Active;
                    DisplayProjectsInTreeView(solution.Projects);
                    if (solutionFilePath != string.Empty)
                    {
                        solution.ExportToFile(solutionFilePath);
                    }
                }
            }
        }

        private void contextMenuStripGroup_Click(object sender, EventArgs e)
        {
            if (selectedGroup != null && selectedGroup.status == DeletedStastus.Deleted)
            {

                var result = MessageBox.Show($"Are you sure you want to restore the group {selectedGroup.Name}?", "Restore Group", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    selectedGroup.status = DeletedStastus.Active;

                    foreach (var request in selectedGroup.HttpRequests)
                    {
                        request.status = DeletedStastus.Active;
                    }
                    DisplayProjectsInTreeView(solution.Projects);
                    if (solutionFilePath != string.Empty)
                    {
                        solution.ExportToFile(solutionFilePath);
                    }
                }
            }
        }

        private void toolStripMenuItemRestoreProject_Click(object sender, EventArgs e)
        {
            if (selectedProject != null && selectedProject.status == DeletedStastus.Deleted)
            {

                var result = MessageBox.Show($"Are you sure you want to restore the project {selectedProject.Name}?", "Restore Project", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    selectedProject.status = DeletedStastus.Active;

                    foreach (var group in selectedProject.Groups)
                    {
                        group.status = DeletedStastus.Active;
                        foreach (var request in group.HttpRequests)
                        {
                            request.status = DeletedStastus.Active;
                        }
                    }
                    DisplayProjectsInTreeView(solution.Projects);
                    if (solutionFilePath != string.Empty)
                    {
                        solution.ExportToFile(solutionFilePath);
                    }
                }
            }
        }

        private void HideRestoreMenuItems()
        {
            toolStripMenuItemRestoreProject.Visible = false;
            toolStripMenuItemRestoreGroup.Visible = false;
            toolStripMenuItemRestoreRequest.Visible = false;


            toolStripMenuItemClearProject.Visible = false;
            toolStripMenuItemClearGroup.Visible = false;
            toolStripMenuItemClearRequest.Visible = false;

        }

        private void toolStripMenuItemClearProject_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show($"Are you sure you want to clear the project {selectedProject.Name}?", "Clear Project", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DeleteProject(selectedProject, true);
            }
        }

        private void toolStripMenuItemClearRequest_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show($"Are you sure you want to clear the request {selectedRequest.Name}?", "Clear Request", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DeleteRequest(selectedRequest, true);
            }

        }

        private void toolStripMenuItemClearGroup_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show($"Are you sure you want to clear the group {selectedGroup.Name}?", "Clear Group", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DeleteGroup(selectedGroup, true);
            }

        }

        private void SetRichTextBoxRequestBodyForRaw()
        {
            richTextBoxRequestBody.Dock = DockStyle.Fill;
            richTextBoxRequestBody.Visible = true;
            dataGridViewRequestBody.Visible = false;
            labelBodyBinaryFile.Visible = false;
            comboBoxRqeuestBodyDataType.Visible = true;
            comboBoxRqeuestBodyDataType.SelectedIndex = 0;
        }


        private void HideRequestBodyControls()
        {
            richTextBoxRequestBody.Visible = false;
            dataGridViewRequestBody.Visible = false;
            labelBodyBinaryFile.Visible = false;
            comboBoxRqeuestBodyDataType.Visible = false;
        }


        private void SetDataGridViewRequestBodyForFormData(bool isurlencoded = false)
        {

            dataGridViewRequestBody.Dock = DockStyle.Fill;
            dataGridViewRequestBody.Visible = true;
            richTextBoxRequestBody.Visible = false;
            labelBodyBinaryFile.Visible = false;
            comboBoxRqeuestBodyDataType.Visible = false;

            dataGridViewRequestBody.Visible = true;

            dataGridViewRequestBody.Columns.Clear();
            dataGridViewRequestBody.Columns.Add("Key", "Key");
            if (isurlencoded == false)
            {
                var typeColumn = new DataGridViewComboBoxColumn
                {
                    Name = "Type",
                    HeaderText = "Type",
                    DataSource = new string[] { "Text", "File" },
                    Width = 100,
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
                };
                dataGridViewRequestBody.Columns.Add(typeColumn);
            }
            dataGridViewRequestBody.Columns.Add("Value", "Value");


            dataGridViewRequestBody.CellValueChanged += DataGridViewRequestBody_CellValueChanged;
            dataGridViewRequestBody.EditingControlShowing += DataGridViewRequestBody_EditingControlShowing;


            if (isurlencoded == true)
            {
                dataGridViewRequestBody.Columns["Key"].Width = dataGridViewRequestBody.Width / 2;
                dataGridViewRequestBody.Columns["Value"].Width = dataGridViewRequestBody.Width / 2;
            }
            else
            {
                dataGridViewRequestBody.Columns["Key"].Width = dataGridViewRequestBody.Width / 5;
                dataGridViewRequestBody.Columns["Value"].Width = dataGridViewRequestBody.Width / 5 * 2;
                dataGridViewRequestBody.Columns["Type"].Width = dataGridViewRequestBody.Width / 5;
            }
        }

        private void DataGridViewRequestBody_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewRequestBody.Columns.Contains("Type") && e.ColumnIndex == dataGridViewRequestBody.Columns["Type"].Index && e.RowIndex >= 0)
            {
                var cell = dataGridViewRequestBody.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
                if (cell != null && cell.Value.ToString() == "File")
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            dataGridViewRequestBody.Rows[e.RowIndex].Cells["Value"].Value = openFileDialog.FileName;
                        }
                    }
                }
            }
        }

        private void DataGridViewRequestBody_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            if (dataGridViewRequestBody.Columns.Contains("Type") && dataGridViewRequestBody.CurrentCell.ColumnIndex == dataGridViewRequestBody.Columns["Type"].Index)
            {
                if (e.Control is ComboBox comboBox)
                {
                    comboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
                    comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
                }
            }

        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.SelectedItem?.ToString() == "File")
            {
                var currentCell = dataGridViewRequestBody.CurrentCell;
                if (currentCell != null)
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            dataGridViewRequestBody.Rows[currentCell.RowIndex].Cells["Value"].Value = openFileDialog.FileName;
                        }
                    }
                }
            }
        }

        private void radioButtonBodyFormData_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBodyFormData.Checked && !dataInitialzing)
            {
                SetDataGridViewRequestBodyForFormData(false);
            }
        }

        private void radioButtonBodyFormurlencoded_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBodyFormurlencoded.Checked && !dataInitialzing)
            {
                SetDataGridViewRequestBodyForFormData(true);
            }
        }

        private void radioButtonBodyRaw_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBodyRaw.Checked && !dataInitialzing)
            {
                SetRichTextBoxRequestBodyForRaw();
            }
        }

        private void radioButtonBodyNone_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBodyNone.Checked && !dataInitialzing)
            {
                HideRequestBodyControls();
            }
        }

        private void radioButtonBodyBinary_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBodyBinary.Checked && !dataInitialzing)
            {
                HideRequestBodyControls();

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        labelBodyBinaryFile.Visible = true;

                        labelBodyBinaryFile.Text = Path.GetFileName(openFileDialog.FileName);
                        labelBodyBinaryFileFull.Text = openFileDialog.FileName;
                    }
                }

            }
        }

        private void tabControlHttpRequest_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControlHttpRequest.SelectedTab == tabPageRequestDetails)
            {
                treeViewRequestDetails.Nodes.Clear();
                if (selectedRequest != null)
                {
                    treeViewRequestDetails.Nodes.Add(new TreeNode($"Name: {selectedRequest.Name}"));
                    treeViewRequestDetails.Nodes.Add(new TreeNode($"Description: {selectedRequest.Description}"));
                    treeViewRequestDetails.Nodes.Add(new TreeNode($"URL: {selectedRequest.RequestParameters.Url}"));
                    treeViewRequestDetails.Nodes.Add(new TreeNode($"Method: {selectedRequest.RequestParameters.Method}"));
                    treeViewRequestDetails.Nodes.Add(new TreeNode($"Content Type: {selectedRequest.RequestParameters.ContentType}"));
                    treeViewRequestDetails.Nodes.Add(new TreeNode("Headers"));
                    foreach (var header in selectedRequest.RequestParameters.Headers)
                    {
                        treeViewRequestDetails.Nodes[5].Nodes.Add(new TreeNode($"{header.Key}: {header.Value}"));
                    }
                    treeViewRequestDetails.Nodes.Add(new TreeNode("Query Parameters"));
                    foreach (var queryParameter in selectedRequest.RequestParameters.QueryParameters)
                    {
                        treeViewRequestDetails.Nodes[6].Nodes.Add(new TreeNode($"{queryParameter.Key}: {queryParameter.Value}"));
                    }
                    treeViewRequestDetails.Nodes.Add(new TreeNode("Body"));
                    treeViewRequestDetails.Nodes[7].Nodes.Add(new TreeNode(selectedRequest.RequestParameters.Body));
                    treeViewRequestDetails.ExpandAll();
                }
            }

        }

        private void listViewRequestHeader_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Delete)
            {
                if (listViewRequestHeader.SelectedItems.Count > 0)
                {
                    listViewRequestHeader.Items.Remove(listViewRequestHeader.SelectedItems[0]);
                }
            }
        }

        private void listViewRequestParameter_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Delete)
            {
                if (listViewRequestParameter.SelectedItems.Count > 0)
                {
                    listViewRequestParameter.Items.Remove(listViewRequestParameter.SelectedItems[0]);
                    UpdateURLAfterParamsChanged();
                }

            }
        }

        private void UpdateURLAfterParamsChanged()
        {
            if (selectedRequest != null && selectedRequest.RequestParameters != null)
            {
                var url = selectedRequest.RequestParameters.Url;
                if (url.Contains("?"))
                {
                    url = url.Substring(0, url.IndexOf("?"));
                }
                var query = string.Empty;
                foreach (ListViewItem item in listViewRequestParameter.Items)
                {
                    query += $"{item.SubItems[0].Text}={item.SubItems[1].Text}&";
                }
                if (query.Length > 0)
                {
                    query = query.Substring(0, query.Length - 1);
                    url += $"?{query}";
                }
                textBoxRequestURL.Text = url;
            }

        }

        private void dataGridViewRequestBody_KeyUp(object sender, KeyEventArgs e)
        {
            //delete the selected row if the delete key is pressed
            if (e.KeyCode == Keys.Delete)
            {
                if (dataGridViewRequestBody.SelectedRows.Count > 0)
                {
                    dataGridViewRequestBody.Rows.Remove(dataGridViewRequestBody.SelectedRows[0]);
                }
            }
        }

        private void dataGridViewRequestBody_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (selectedRequest != null)
            {
                AddRequestBodyDetails(selectedRequest.RequestParameters);
            }

        }

        private void dataGridViewRequestBody_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (selectedRequest != null)
            {
                AddRequestBodyDetails(selectedRequest.RequestParameters);
            }
        }

        private void ToolStripMenuItemcopyRequestInfo_Click(object sender, EventArgs e)
        {
            objectInCopy = CopyRequestContent(selectedRequest);
            toolStripMenuItemPasteRequestInfo.Enabled = true;
            toolStripMenuItemPasteToGroup.Visible = true;
        }
         
        private RequestInfo CopyRequestContent(RequestInfo request)
        {
            return new RequestInfo
            {
                Name = request.Name,
                Id = Guid.NewGuid(),
                Description = request.Description,
                RequestParameters = new Req(request.RequestParameters.Method, request.RequestParameters.Url)
                {
                    Body = request.RequestParameters.Body,
                    ContentType = request.RequestParameters.ContentType,
                    Headers = request.RequestParameters.Headers,
                    QueryParameters = request.RequestParameters.QueryParameters
                }
            };
        }


        private void toolStripMenuItemPasteRequestInfo_Click(object sender, EventArgs e)
        {
            //create a new request under the selected group by using information in the objectInCopy
            if (objectInCopy != null && objectInCopy is RequestInfo request)
            {
                var newRequest = new RequestInfo
                {
                    Name = request.Name + "--copied",
                    Id = Guid.NewGuid(),
                    Description = request.Description,
                    RequestParameters = new Req(request.RequestParameters.Method, request.RequestParameters.Url)
                    {
                        Body = request.RequestParameters.Body,
                        ContentType = request.RequestParameters.ContentType,
                        Headers = request.RequestParameters.Headers,
                        QueryParameters = request.RequestParameters.QueryParameters
                    }
                };
                selectedGroup.HttpRequests.Add(newRequest);
                DisplayProjectsInTreeView(solution.Projects);
                if (solutionFilePath != string.Empty)
                {
                    solution.ExportToFile(solutionFilePath);
                }
            }else
            {
                MessageBox.Show("No object to paste.");
            }
            objectInCopy = null;
            toolStripMenuItemPasteRequestInfo.Enabled = false;
            toolStripMenuItemPasteToGroup.Visible = false;
        }

        private void ToolStripMenuItemduplicateRequestInfo_Click(object sender, EventArgs e)
        {
            //create a new request under the selected group by using information in the selectedRequest
            if (selectedRequest != null)
            {
                var newRequest = new RequestInfo
                {
                    Name = selectedRequest.Name + "--duplicated",
                    Id = Guid.NewGuid(),
                    Description = selectedRequest.Description,
                    RequestParameters = new Req(selectedRequest.RequestParameters.Method, selectedRequest.RequestParameters.Url)
                    {
                        Body = selectedRequest.RequestParameters.Body,
                        ContentType = selectedRequest.RequestParameters.ContentType,
                        Headers = selectedRequest.RequestParameters.Headers,
                        QueryParameters = selectedRequest.RequestParameters.QueryParameters
                    }
                };
                selectedGroup.HttpRequests.Add(newRequest);
                DisplayProjectsInTreeView(solution.Projects);
                if (solutionFilePath != string.Empty)
                {
                    solution.ExportToFile(solutionFilePath);
                }
            }
        }

        private void toolStripMenuItemPasteToGroup_Click(object sender, EventArgs e)
        {
            //paste the objectInCopy as requestinfo to the selected group if it's not null, hide the paste menu item after pasting
            if (objectInCopy != null && objectInCopy is RequestInfo request)
            {
                request.Name = request.Name + "--copied";
                request.Id = Guid.NewGuid();
                selectedGroup.HttpRequests.Add(request);
                DisplayProjectsInTreeView(solution.Projects);
                if (solutionFilePath != string.Empty)
                {
                    solution.ExportToFile(solutionFilePath);
                }
            }else
            {
                MessageBox.Show("No object to paste.");
            }
            objectInCopy = null;
            toolStripMenuItemPasteRequestInfo.Enabled = false;
            toolStripMenuItemPasteToGroup.Visible = false;
        }
    }
}