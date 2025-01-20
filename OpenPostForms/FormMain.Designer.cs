namespace OpenPostForms
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ListViewItem listViewItem1 = new ListViewItem("Key");
            ListViewItem listViewItem2 = new ListViewItem("Value");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            menuStripMain = new MenuStrip();
            toolStripMenuItemSolution = new ToolStripMenuItem();
            openToolStripMenuItemNewSolution = new ToolStripMenuItem();
            openToolStripMenuItemOpenSolution = new ToolStripMenuItem();
            saveToolStripMenuItemSaveSolution = new ToolStripMenuItem();
            saveAsToolStripMenuItemSaveasSolution = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItemNewProject = new ToolStripMenuItem();
            toolStripMenuItemNewFlow = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripMenuItemViewAll = new ToolStripMenuItem();
            toolStripMenuItemClearDeleted = new ToolStripMenuItem();
            toolStripMenuItemFlow = new ToolStripMenuItem();
            tabControlMain = new TabControl();
            tabPageProject = new TabPage();
            treeViewProjects = new TreeView();
            tabPageFlow = new TabPage();
            panelWorkspace = new Panel();
            tabControlHttpResponse = new TabControl();
            tabPageResponseOverview = new TabPage();
            treeViewResponse = new TreeView();
            tabPageResponseBody = new TabPage();
            tabControlResponseBodyView = new TabControl();
            tabPageResponseBodyInText = new TabPage();
            richTextBoxResponseBodyInText = new RichTextBox();
            tabPageResponseBodyInHTML = new TabPage();
            webView2ResponseBodyInHTML = new Microsoft.Web.WebView2.WinForms.WebView2();
            tabPageResponseBodyInHex = new TabPage();
            richTextBoxResponseBodyInHex = new RichTextBox();
            tabControlHttpRequest = new TabControl();
            tabPageRequest = new TabPage();
            groupBoxRequestParams = new GroupBox();
            listViewRequestParameter = new ListView();
            panelRequestParameter = new Panel();
            buttonNewParamAdd = new Button();
            textBoxNewParamValue = new TextBox();
            labelNewParamValue = new Label();
            textBoxNewParamKey = new TextBox();
            labelNewParamKey = new Label();
            listViewQueryHistory = new ListView();
            ColumnHeaderHistory = new ColumnHeader();
            labelRequestPath = new Label();
            buttonRequestQuery = new Button();
            buttonRequestSave = new Button();
            comboBoxRequestMethod = new ComboBox();
            labelRequestMethod = new Label();
            textBoxRequestURL = new TextBox();
            labelRequestURL = new Label();
            textBoxRequestDescription = new TextBox();
            labelRequestDescription = new Label();
            textBoxRequestName = new TextBox();
            labelRequestName = new Label();
            tabPageHeader = new TabPage();
            listViewRequestHeader = new ListView();
            panelRequestHeader = new Panel();
            buttonNewHeaderAdd = new Button();
            textBoxNewHeaderValue = new TextBox();
            labelNewHeaderValue = new Label();
            textBoxNewHeaderKey = new TextBox();
            labelNewHeaderKey = new Label();
            tabPageBody = new TabPage();
            dataGridViewRequestBody = new DataGridView();
            richTextBoxRequestBody = new RichTextBox();
            panelRequestBody = new Panel();
            labelBodyBinaryFileFull = new Label();
            labelBodyBinaryFile = new Label();
            radioButtonBodyBinary = new RadioButton();
            radioButtonBodyRaw = new RadioButton();
            radioButtonBodyFormurlencoded = new RadioButton();
            radioButtonBodyFormData = new RadioButton();
            radioButtonBodyNone = new RadioButton();
            comboBoxRqeuestBodyDataType = new ComboBox();
            tabPageRequestDetails = new TabPage();
            treeViewRequestDetails = new TreeView();
            contextMenuStripProject = new ContextMenuStrip(components);
            newToolStripMenuItem = new ToolStripMenuItem();
            renameProjectToolStripMenuItem = new ToolStripMenuItem();
            toolStripTextBoxProjectName = new ToolStripTextBox();
            toolStripMenuItemSetProjectName = new ToolStripMenuItem();
            deleteProjectToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItemRestoreProject = new ToolStripMenuItem();
            toolStripMenuItemClearProject = new ToolStripMenuItem();
            contextMenuStripGroup = new ContextMenuStrip(components);
            newRequestToolStripMenuItem = new ToolStripMenuItem();
            renameGroupToolStripMenuItem = new ToolStripMenuItem();
            toolStripTextBoxGroupName = new ToolStripTextBox();
            toolStripMenuItemSaveGroupName = new ToolStripMenuItem();
            deleteGroupToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItemRestoreGroup = new ToolStripMenuItem();
            toolStripMenuItemClearGroup = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripMenuItemPasteToGroup = new ToolStripMenuItem();
            contextMenuStripHttpRequestInfo = new ContextMenuStrip(components);
            ToolStripMenuItemcopyRequestInfo = new ToolStripMenuItem();
            toolStripMenuItemPasteRequestInfo = new ToolStripMenuItem();
            ToolStripMenuItemduplicateRequestInfo = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItemRestoreRequest = new ToolStripMenuItem();
            toolStripMenuItemClearRequest = new ToolStripMenuItem();
            menuStripMain.SuspendLayout();
            tabControlMain.SuspendLayout();
            tabPageProject.SuspendLayout();
            panelWorkspace.SuspendLayout();
            tabControlHttpResponse.SuspendLayout();
            tabPageResponseOverview.SuspendLayout();
            tabPageResponseBody.SuspendLayout();
            tabControlResponseBodyView.SuspendLayout();
            tabPageResponseBodyInText.SuspendLayout();
            tabPageResponseBodyInHTML.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView2ResponseBodyInHTML).BeginInit();
            tabPageResponseBodyInHex.SuspendLayout();
            tabControlHttpRequest.SuspendLayout();
            tabPageRequest.SuspendLayout();
            groupBoxRequestParams.SuspendLayout();
            panelRequestParameter.SuspendLayout();
            tabPageHeader.SuspendLayout();
            panelRequestHeader.SuspendLayout();
            tabPageBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRequestBody).BeginInit();
            panelRequestBody.SuspendLayout();
            tabPageRequestDetails.SuspendLayout();
            contextMenuStripProject.SuspendLayout();
            contextMenuStripGroup.SuspendLayout();
            contextMenuStripHttpRequestInfo.SuspendLayout();
            SuspendLayout();
            // 
            // menuStripMain
            // 
            menuStripMain.ImageScalingSize = new Size(24, 24);
            menuStripMain.Items.AddRange(new ToolStripItem[] { toolStripMenuItemSolution, toolStripMenuItemFlow });
            menuStripMain.Location = new Point(0, 0);
            menuStripMain.Name = "menuStripMain";
            menuStripMain.Size = new Size(2051, 32);
            menuStripMain.TabIndex = 0;
            menuStripMain.Text = "Main";
            // 
            // toolStripMenuItemSolution
            // 
            toolStripMenuItemSolution.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItemNewSolution, openToolStripMenuItemOpenSolution, saveToolStripMenuItemSaveSolution, saveAsToolStripMenuItemSaveasSolution, toolStripSeparator1, toolStripMenuItemNewProject, toolStripMenuItemNewFlow, toolStripSeparator2, toolStripMenuItemViewAll, toolStripMenuItemClearDeleted });
            toolStripMenuItemSolution.Name = "toolStripMenuItemSolution";
            toolStripMenuItemSolution.Size = new Size(97, 28);
            toolStripMenuItemSolution.Text = "Solution";
            // 
            // openToolStripMenuItemNewSolution
            // 
            openToolStripMenuItemNewSolution.Name = "openToolStripMenuItemNewSolution";
            openToolStripMenuItemNewSolution.Size = new Size(279, 34);
            openToolStripMenuItemNewSolution.Text = "New";
            openToolStripMenuItemNewSolution.Click += openToolStripMenuItemNewProject_Click;
            // 
            // openToolStripMenuItemOpenSolution
            // 
            openToolStripMenuItemOpenSolution.Name = "openToolStripMenuItemOpenSolution";
            openToolStripMenuItemOpenSolution.Size = new Size(279, 34);
            openToolStripMenuItemOpenSolution.Text = "Open";
            openToolStripMenuItemOpenSolution.Click += openToolStripMenuItemOpenProject_Click;
            // 
            // saveToolStripMenuItemSaveSolution
            // 
            saveToolStripMenuItemSaveSolution.Name = "saveToolStripMenuItemSaveSolution";
            saveToolStripMenuItemSaveSolution.Size = new Size(279, 34);
            saveToolStripMenuItemSaveSolution.Text = "Save";
            saveToolStripMenuItemSaveSolution.Click += saveToolStripMenuItemSaveProject_Click;
            // 
            // saveAsToolStripMenuItemSaveasSolution
            // 
            saveAsToolStripMenuItemSaveasSolution.Name = "saveAsToolStripMenuItemSaveasSolution";
            saveAsToolStripMenuItemSaveasSolution.Size = new Size(279, 34);
            saveAsToolStripMenuItemSaveasSolution.Text = "Save As";
            saveAsToolStripMenuItemSaveasSolution.Click += saveAsToolStripMenuItemSaveasProject_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(276, 6);
            // 
            // toolStripMenuItemNewProject
            // 
            toolStripMenuItemNewProject.Name = "toolStripMenuItemNewProject";
            toolStripMenuItemNewProject.Size = new Size(279, 34);
            toolStripMenuItemNewProject.Text = "New Project";
            toolStripMenuItemNewProject.Click += toolStripMenuItemNewProject_Click;
            // 
            // toolStripMenuItemNewFlow
            // 
            toolStripMenuItemNewFlow.Name = "toolStripMenuItemNewFlow";
            toolStripMenuItemNewFlow.Size = new Size(279, 34);
            toolStripMenuItemNewFlow.Text = "New Flow";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(276, 6);
            // 
            // toolStripMenuItemViewAll
            // 
            toolStripMenuItemViewAll.Name = "toolStripMenuItemViewAll";
            toolStripMenuItemViewAll.Size = new Size(279, 34);
            toolStripMenuItemViewAll.Text = "View All Items";
            toolStripMenuItemViewAll.Click += toolStripMenuItemViewAll_Click;
            // 
            // toolStripMenuItemClearDeleted
            // 
            toolStripMenuItemClearDeleted.Name = "toolStripMenuItemClearDeleted";
            toolStripMenuItemClearDeleted.Size = new Size(279, 34);
            toolStripMenuItemClearDeleted.Text = "Clear Deleted Items";
            toolStripMenuItemClearDeleted.Visible = false;
            toolStripMenuItemClearDeleted.Click += toolStripMenuItemClearDeleted_Click;
            // 
            // toolStripMenuItemFlow
            // 
            toolStripMenuItemFlow.Name = "toolStripMenuItemFlow";
            toolStripMenuItemFlow.Size = new Size(66, 28);
            toolStripMenuItemFlow.Text = "Flow";
            // 
            // tabControlMain
            // 
            tabControlMain.Alignment = TabAlignment.Left;
            tabControlMain.Controls.Add(tabPageProject);
            tabControlMain.Controls.Add(tabPageFlow);
            tabControlMain.Dock = DockStyle.Left;
            tabControlMain.Location = new Point(0, 32);
            tabControlMain.Multiline = true;
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.ShowToolTips = true;
            tabControlMain.Size = new Size(506, 1141);
            tabControlMain.SizeMode = TabSizeMode.Fixed;
            tabControlMain.TabIndex = 1;
            // 
            // tabPageProject
            // 
            tabPageProject.Controls.Add(treeViewProjects);
            tabPageProject.Location = new Point(33, 4);
            tabPageProject.Name = "tabPageProject";
            tabPageProject.Padding = new Padding(3);
            tabPageProject.Size = new Size(469, 1133);
            tabPageProject.TabIndex = 0;
            tabPageProject.Text = "Projects";
            tabPageProject.UseVisualStyleBackColor = true;
            // 
            // treeViewProjects
            // 
            treeViewProjects.Dock = DockStyle.Fill;
            treeViewProjects.Location = new Point(3, 3);
            treeViewProjects.Name = "treeViewProjects";
            treeViewProjects.Size = new Size(463, 1127);
            treeViewProjects.TabIndex = 0;
            treeViewProjects.NodeMouseClick += treeViewProjects_NodeMouseClick;
            // 
            // tabPageFlow
            // 
            tabPageFlow.Location = new Point(33, 4);
            tabPageFlow.Name = "tabPageFlow";
            tabPageFlow.Padding = new Padding(3);
            tabPageFlow.Size = new Size(469, 1133);
            tabPageFlow.TabIndex = 1;
            tabPageFlow.Text = "Flows";
            tabPageFlow.UseVisualStyleBackColor = true;
            // 
            // panelWorkspace
            // 
            panelWorkspace.Controls.Add(tabControlHttpResponse);
            panelWorkspace.Controls.Add(tabControlHttpRequest);
            panelWorkspace.Dock = DockStyle.Fill;
            panelWorkspace.Location = new Point(506, 32);
            panelWorkspace.Name = "panelWorkspace";
            panelWorkspace.Size = new Size(1545, 1141);
            panelWorkspace.TabIndex = 2;
            // 
            // tabControlHttpResponse
            // 
            tabControlHttpResponse.Controls.Add(tabPageResponseOverview);
            tabControlHttpResponse.Controls.Add(tabPageResponseBody);
            tabControlHttpResponse.Dock = DockStyle.Fill;
            tabControlHttpResponse.Location = new Point(0, 505);
            tabControlHttpResponse.Name = "tabControlHttpResponse";
            tabControlHttpResponse.SelectedIndex = 0;
            tabControlHttpResponse.Size = new Size(1545, 636);
            tabControlHttpResponse.TabIndex = 1;
            // 
            // tabPageResponseOverview
            // 
            tabPageResponseOverview.Controls.Add(treeViewResponse);
            tabPageResponseOverview.Location = new Point(4, 33);
            tabPageResponseOverview.Name = "tabPageResponseOverview";
            tabPageResponseOverview.Padding = new Padding(3);
            tabPageResponseOverview.Size = new Size(1537, 599);
            tabPageResponseOverview.TabIndex = 2;
            tabPageResponseOverview.Text = "Response";
            tabPageResponseOverview.UseVisualStyleBackColor = true;
            // 
            // treeViewResponse
            // 
            treeViewResponse.Dock = DockStyle.Fill;
            treeViewResponse.Location = new Point(3, 3);
            treeViewResponse.Name = "treeViewResponse";
            treeViewResponse.Size = new Size(1531, 593);
            treeViewResponse.TabIndex = 0;
            // 
            // tabPageResponseBody
            // 
            tabPageResponseBody.Controls.Add(tabControlResponseBodyView);
            tabPageResponseBody.Location = new Point(4, 33);
            tabPageResponseBody.Name = "tabPageResponseBody";
            tabPageResponseBody.Padding = new Padding(3);
            tabPageResponseBody.Size = new Size(1537, 680);
            tabPageResponseBody.TabIndex = 0;
            tabPageResponseBody.Text = "Body";
            tabPageResponseBody.UseVisualStyleBackColor = true;
            // 
            // tabControlResponseBodyView
            // 
            tabControlResponseBodyView.Alignment = TabAlignment.Bottom;
            tabControlResponseBodyView.Controls.Add(tabPageResponseBodyInText);
            tabControlResponseBodyView.Controls.Add(tabPageResponseBodyInHTML);
            tabControlResponseBodyView.Controls.Add(tabPageResponseBodyInHex);
            tabControlResponseBodyView.Dock = DockStyle.Fill;
            tabControlResponseBodyView.Location = new Point(3, 3);
            tabControlResponseBodyView.Multiline = true;
            tabControlResponseBodyView.Name = "tabControlResponseBodyView";
            tabControlResponseBodyView.SelectedIndex = 0;
            tabControlResponseBodyView.Size = new Size(1531, 674);
            tabControlResponseBodyView.TabIndex = 0;
            tabControlResponseBodyView.SelectedIndexChanged += tabControlResponseBodyView_SelectedIndexChanged;
            // 
            // tabPageResponseBodyInText
            // 
            tabPageResponseBodyInText.Controls.Add(richTextBoxResponseBodyInText);
            tabPageResponseBodyInText.Location = new Point(4, 4);
            tabPageResponseBodyInText.Name = "tabPageResponseBodyInText";
            tabPageResponseBodyInText.Padding = new Padding(3);
            tabPageResponseBodyInText.Size = new Size(1523, 637);
            tabPageResponseBodyInText.TabIndex = 0;
            tabPageResponseBodyInText.Text = "Text";
            tabPageResponseBodyInText.UseVisualStyleBackColor = true;
            // 
            // richTextBoxResponseBodyInText
            // 
            richTextBoxResponseBodyInText.Dock = DockStyle.Fill;
            richTextBoxResponseBodyInText.Location = new Point(3, 3);
            richTextBoxResponseBodyInText.Name = "richTextBoxResponseBodyInText";
            richTextBoxResponseBodyInText.ReadOnly = true;
            richTextBoxResponseBodyInText.Size = new Size(1517, 631);
            richTextBoxResponseBodyInText.TabIndex = 0;
            richTextBoxResponseBodyInText.Text = "";
            // 
            // tabPageResponseBodyInHTML
            // 
            tabPageResponseBodyInHTML.Controls.Add(webView2ResponseBodyInHTML);
            tabPageResponseBodyInHTML.Location = new Point(4, 4);
            tabPageResponseBodyInHTML.Name = "tabPageResponseBodyInHTML";
            tabPageResponseBodyInHTML.Padding = new Padding(3);
            tabPageResponseBodyInHTML.Size = new Size(1523, 637);
            tabPageResponseBodyInHTML.TabIndex = 1;
            tabPageResponseBodyInHTML.Text = "HTML";
            tabPageResponseBodyInHTML.UseVisualStyleBackColor = true;
            // 
            // webView2ResponseBodyInHTML
            // 
            webView2ResponseBodyInHTML.AllowExternalDrop = true;
            webView2ResponseBodyInHTML.CreationProperties = null;
            webView2ResponseBodyInHTML.DefaultBackgroundColor = Color.White;
            webView2ResponseBodyInHTML.Dock = DockStyle.Fill;
            webView2ResponseBodyInHTML.Location = new Point(3, 3);
            webView2ResponseBodyInHTML.Name = "webView2ResponseBodyInHTML";
            webView2ResponseBodyInHTML.Size = new Size(1517, 631);
            webView2ResponseBodyInHTML.TabIndex = 0;
            webView2ResponseBodyInHTML.ZoomFactor = 1D;
            // 
            // tabPageResponseBodyInHex
            // 
            tabPageResponseBodyInHex.Controls.Add(richTextBoxResponseBodyInHex);
            tabPageResponseBodyInHex.Location = new Point(4, 4);
            tabPageResponseBodyInHex.Name = "tabPageResponseBodyInHex";
            tabPageResponseBodyInHex.Padding = new Padding(3);
            tabPageResponseBodyInHex.Size = new Size(1523, 637);
            tabPageResponseBodyInHex.TabIndex = 2;
            tabPageResponseBodyInHex.Text = "HEX";
            tabPageResponseBodyInHex.UseVisualStyleBackColor = true;
            // 
            // richTextBoxResponseBodyInHex
            // 
            richTextBoxResponseBodyInHex.Dock = DockStyle.Fill;
            richTextBoxResponseBodyInHex.Location = new Point(3, 3);
            richTextBoxResponseBodyInHex.Name = "richTextBoxResponseBodyInHex";
            richTextBoxResponseBodyInHex.ReadOnly = true;
            richTextBoxResponseBodyInHex.Size = new Size(1517, 631);
            richTextBoxResponseBodyInHex.TabIndex = 0;
            richTextBoxResponseBodyInHex.Text = "";
            // 
            // tabControlHttpRequest
            // 
            tabControlHttpRequest.Controls.Add(tabPageRequest);
            tabControlHttpRequest.Controls.Add(tabPageHeader);
            tabControlHttpRequest.Controls.Add(tabPageBody);
            tabControlHttpRequest.Controls.Add(tabPageRequestDetails);
            tabControlHttpRequest.Dock = DockStyle.Top;
            tabControlHttpRequest.Location = new Point(0, 0);
            tabControlHttpRequest.Name = "tabControlHttpRequest";
            tabControlHttpRequest.SelectedIndex = 0;
            tabControlHttpRequest.Size = new Size(1545, 505);
            tabControlHttpRequest.TabIndex = 0;
            tabControlHttpRequest.SelectedIndexChanged += tabControlHttpRequest_SelectedIndexChanged;
            // 
            // tabPageRequest
            // 
            tabPageRequest.Controls.Add(groupBoxRequestParams);
            tabPageRequest.Controls.Add(listViewQueryHistory);
            tabPageRequest.Controls.Add(labelRequestPath);
            tabPageRequest.Controls.Add(buttonRequestQuery);
            tabPageRequest.Controls.Add(buttonRequestSave);
            tabPageRequest.Controls.Add(comboBoxRequestMethod);
            tabPageRequest.Controls.Add(labelRequestMethod);
            tabPageRequest.Controls.Add(textBoxRequestURL);
            tabPageRequest.Controls.Add(labelRequestURL);
            tabPageRequest.Controls.Add(textBoxRequestDescription);
            tabPageRequest.Controls.Add(labelRequestDescription);
            tabPageRequest.Controls.Add(textBoxRequestName);
            tabPageRequest.Controls.Add(labelRequestName);
            tabPageRequest.Location = new Point(4, 33);
            tabPageRequest.Name = "tabPageRequest";
            tabPageRequest.Padding = new Padding(3);
            tabPageRequest.Size = new Size(1537, 468);
            tabPageRequest.TabIndex = 0;
            tabPageRequest.Text = "Request";
            tabPageRequest.UseVisualStyleBackColor = true;
            // 
            // groupBoxRequestParams
            // 
            groupBoxRequestParams.Controls.Add(listViewRequestParameter);
            groupBoxRequestParams.Controls.Add(panelRequestParameter);
            groupBoxRequestParams.Dock = DockStyle.Bottom;
            groupBoxRequestParams.Location = new Point(3, 208);
            groupBoxRequestParams.Name = "groupBoxRequestParams";
            groupBoxRequestParams.Size = new Size(1316, 257);
            groupBoxRequestParams.TabIndex = 14;
            groupBoxRequestParams.TabStop = false;
            groupBoxRequestParams.Text = "Params";
            // 
            // listViewRequestParameter
            // 
            listViewRequestParameter.Dock = DockStyle.Fill;
            listViewRequestParameter.Location = new Point(3, 86);
            listViewRequestParameter.Name = "listViewRequestParameter";
            listViewRequestParameter.Size = new Size(1310, 168);
            listViewRequestParameter.TabIndex = 5;
            listViewRequestParameter.UseCompatibleStateImageBehavior = false;
            listViewRequestParameter.KeyUp += listViewRequestParameter_KeyUp;
            // 
            // panelRequestParameter
            // 
            panelRequestParameter.Controls.Add(buttonNewParamAdd);
            panelRequestParameter.Controls.Add(textBoxNewParamValue);
            panelRequestParameter.Controls.Add(labelNewParamValue);
            panelRequestParameter.Controls.Add(textBoxNewParamKey);
            panelRequestParameter.Controls.Add(labelNewParamKey);
            panelRequestParameter.Dock = DockStyle.Top;
            panelRequestParameter.Location = new Point(3, 26);
            panelRequestParameter.Name = "panelRequestParameter";
            panelRequestParameter.Size = new Size(1310, 60);
            panelRequestParameter.TabIndex = 4;
            // 
            // buttonNewParamAdd
            // 
            buttonNewParamAdd.Location = new Point(1121, 13);
            buttonNewParamAdd.Name = "buttonNewParamAdd";
            buttonNewParamAdd.Size = new Size(112, 34);
            buttonNewParamAdd.TabIndex = 8;
            buttonNewParamAdd.Text = "Add";
            buttonNewParamAdd.UseVisualStyleBackColor = true;
            buttonNewParamAdd.Click += buttonNewParamAdd_Click;
            // 
            // textBoxNewParamValue
            // 
            textBoxNewParamValue.Location = new Point(581, 16);
            textBoxNewParamValue.Name = "textBoxNewParamValue";
            textBoxNewParamValue.Size = new Size(500, 30);
            textBoxNewParamValue.TabIndex = 7;
            // 
            // labelNewParamValue
            // 
            labelNewParamValue.AutoSize = true;
            labelNewParamValue.Location = new Point(495, 18);
            labelNewParamValue.Name = "labelNewParamValue";
            labelNewParamValue.Size = new Size(58, 24);
            labelNewParamValue.TabIndex = 6;
            labelNewParamValue.Text = "Value";
            // 
            // textBoxNewParamKey
            // 
            textBoxNewParamKey.Location = new Point(107, 15);
            textBoxNewParamKey.Name = "textBoxNewParamKey";
            textBoxNewParamKey.Size = new Size(293, 30);
            textBoxNewParamKey.TabIndex = 5;
            // 
            // labelNewParamKey
            // 
            labelNewParamKey.AutoSize = true;
            labelNewParamKey.Location = new Point(9, 17);
            labelNewParamKey.Name = "labelNewParamKey";
            labelNewParamKey.Size = new Size(41, 24);
            labelNewParamKey.TabIndex = 4;
            labelNewParamKey.Text = "Key";
            // 
            // listViewQueryHistory
            // 
            listViewQueryHistory.Columns.AddRange(new ColumnHeader[] { ColumnHeaderHistory });
            listViewQueryHistory.Dock = DockStyle.Right;
            listViewQueryHistory.FullRowSelect = true;
            listViewQueryHistory.Location = new Point(1319, 3);
            listViewQueryHistory.MultiSelect = false;
            listViewQueryHistory.Name = "listViewQueryHistory";
            listViewQueryHistory.Size = new Size(215, 462);
            listViewQueryHistory.TabIndex = 13;
            listViewQueryHistory.UseCompatibleStateImageBehavior = false;
            listViewQueryHistory.View = View.Details;
            listViewQueryHistory.SelectedIndexChanged += listViewQueryHistory_SelectedIndexChanged;
            // 
            // ColumnHeaderHistory
            // 
            ColumnHeaderHistory.Text = "History";
            ColumnHeaderHistory.Width = 600;
            // 
            // labelRequestPath
            // 
            labelRequestPath.AutoSize = true;
            labelRequestPath.ForeColor = SystemColors.Highlight;
            labelRequestPath.Location = new Point(20, 23);
            labelRequestPath.Name = "labelRequestPath";
            labelRequestPath.Size = new Size(49, 24);
            labelRequestPath.TabIndex = 12;
            labelRequestPath.Text = "Path";
            // 
            // buttonRequestQuery
            // 
            buttonRequestQuery.Location = new Point(1024, 71);
            buttonRequestQuery.Name = "buttonRequestQuery";
            buttonRequestQuery.Size = new Size(112, 50);
            buttonRequestQuery.TabIndex = 9;
            buttonRequestQuery.Text = "Query";
            buttonRequestQuery.UseVisualStyleBackColor = true;
            buttonRequestQuery.Click += buttonRequestQuery_Click;
            // 
            // buttonRequestSave
            // 
            buttonRequestSave.Location = new Point(1178, 71);
            buttonRequestSave.Name = "buttonRequestSave";
            buttonRequestSave.Size = new Size(112, 50);
            buttonRequestSave.TabIndex = 8;
            buttonRequestSave.Text = "Save";
            buttonRequestSave.UseVisualStyleBackColor = true;
            buttonRequestSave.Click += buttonRequestSave_Click;
            // 
            // comboBoxRequestMethod
            // 
            comboBoxRequestMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRequestMethod.FormattingEnabled = true;
            comboBoxRequestMethod.Items.AddRange(new object[] { "GET", "POST", "PUT", "DELETE", "PATCH", "HEAD", "OPTIONS", "CONNECT", "TRACE" });
            comboBoxRequestMethod.Location = new Point(117, 80);
            comboBoxRequestMethod.Name = "comboBoxRequestMethod";
            comboBoxRequestMethod.Size = new Size(144, 32);
            comboBoxRequestMethod.TabIndex = 7;
            // 
            // labelRequestMethod
            // 
            labelRequestMethod.AutoSize = true;
            labelRequestMethod.Location = new Point(10, 84);
            labelRequestMethod.Name = "labelRequestMethod";
            labelRequestMethod.Size = new Size(87, 24);
            labelRequestMethod.TabIndex = 6;
            labelRequestMethod.Text = "Method*";
            // 
            // textBoxRequestURL
            // 
            textBoxRequestURL.Location = new Point(449, 84);
            textBoxRequestURL.Name = "textBoxRequestURL";
            textBoxRequestURL.Size = new Size(546, 30);
            textBoxRequestURL.TabIndex = 5;
            textBoxRequestURL.TextChanged += textBoxRequestURL_TextChanged;
            // 
            // labelRequestURL
            // 
            labelRequestURL.AutoSize = true;
            labelRequestURL.Location = new Point(304, 87);
            labelRequestURL.Name = "labelRequestURL";
            labelRequestURL.Size = new Size(52, 24);
            labelRequestURL.TabIndex = 4;
            labelRequestURL.Text = "URL*";
            // 
            // textBoxRequestDescription
            // 
            textBoxRequestDescription.Location = new Point(449, 141);
            textBoxRequestDescription.Name = "textBoxRequestDescription";
            textBoxRequestDescription.Size = new Size(841, 30);
            textBoxRequestDescription.TabIndex = 3;
            // 
            // labelRequestDescription
            // 
            labelRequestDescription.AutoSize = true;
            labelRequestDescription.Location = new Point(304, 144);
            labelRequestDescription.Name = "labelRequestDescription";
            labelRequestDescription.Size = new Size(109, 24);
            labelRequestDescription.TabIndex = 2;
            labelRequestDescription.Text = "Description";
            // 
            // textBoxRequestName
            // 
            textBoxRequestName.Location = new Point(117, 138);
            textBoxRequestName.Name = "textBoxRequestName";
            textBoxRequestName.Size = new Size(144, 30);
            textBoxRequestName.TabIndex = 1;
            // 
            // labelRequestName
            // 
            labelRequestName.AutoSize = true;
            labelRequestName.Location = new Point(10, 141);
            labelRequestName.Name = "labelRequestName";
            labelRequestName.Size = new Size(62, 24);
            labelRequestName.TabIndex = 0;
            labelRequestName.Text = "Name";
            // 
            // tabPageHeader
            // 
            tabPageHeader.Controls.Add(listViewRequestHeader);
            tabPageHeader.Controls.Add(panelRequestHeader);
            tabPageHeader.Location = new Point(4, 33);
            tabPageHeader.Name = "tabPageHeader";
            tabPageHeader.Padding = new Padding(3);
            tabPageHeader.Size = new Size(1537, 387);
            tabPageHeader.TabIndex = 1;
            tabPageHeader.Text = "Header";
            tabPageHeader.UseVisualStyleBackColor = true;
            // 
            // listViewRequestHeader
            // 
            listViewRequestHeader.Dock = DockStyle.Fill;
            listViewRequestHeader.FullRowSelect = true;
            listViewRequestHeader.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2 });
            listViewRequestHeader.Location = new Point(3, 63);
            listViewRequestHeader.Name = "listViewRequestHeader";
            listViewRequestHeader.Size = new Size(1531, 321);
            listViewRequestHeader.TabIndex = 1;
            listViewRequestHeader.UseCompatibleStateImageBehavior = false;
            listViewRequestHeader.View = View.Details;
            listViewRequestHeader.KeyUp += listViewRequestHeader_KeyUp;
            // 
            // panelRequestHeader
            // 
            panelRequestHeader.Controls.Add(buttonNewHeaderAdd);
            panelRequestHeader.Controls.Add(textBoxNewHeaderValue);
            panelRequestHeader.Controls.Add(labelNewHeaderValue);
            panelRequestHeader.Controls.Add(textBoxNewHeaderKey);
            panelRequestHeader.Controls.Add(labelNewHeaderKey);
            panelRequestHeader.Dock = DockStyle.Top;
            panelRequestHeader.Location = new Point(3, 3);
            panelRequestHeader.Name = "panelRequestHeader";
            panelRequestHeader.Size = new Size(1531, 60);
            panelRequestHeader.TabIndex = 0;
            // 
            // buttonNewHeaderAdd
            // 
            buttonNewHeaderAdd.Location = new Point(1275, 13);
            buttonNewHeaderAdd.Name = "buttonNewHeaderAdd";
            buttonNewHeaderAdd.Size = new Size(112, 34);
            buttonNewHeaderAdd.TabIndex = 4;
            buttonNewHeaderAdd.Text = "Add";
            buttonNewHeaderAdd.UseVisualStyleBackColor = true;
            buttonNewHeaderAdd.Click += buttonNewHeaderAdd_Click;
            // 
            // textBoxNewHeaderValue
            // 
            textBoxNewHeaderValue.Location = new Point(581, 16);
            textBoxNewHeaderValue.Name = "textBoxNewHeaderValue";
            textBoxNewHeaderValue.Size = new Size(632, 30);
            textBoxNewHeaderValue.TabIndex = 3;
            // 
            // labelNewHeaderValue
            // 
            labelNewHeaderValue.AutoSize = true;
            labelNewHeaderValue.Location = new Point(495, 18);
            labelNewHeaderValue.Name = "labelNewHeaderValue";
            labelNewHeaderValue.Size = new Size(58, 24);
            labelNewHeaderValue.TabIndex = 2;
            labelNewHeaderValue.Text = "Value";
            // 
            // textBoxNewHeaderKey
            // 
            textBoxNewHeaderKey.Location = new Point(102, 15);
            textBoxNewHeaderKey.Name = "textBoxNewHeaderKey";
            textBoxNewHeaderKey.Size = new Size(293, 30);
            textBoxNewHeaderKey.TabIndex = 1;
            // 
            // labelNewHeaderKey
            // 
            labelNewHeaderKey.AutoSize = true;
            labelNewHeaderKey.Location = new Point(16, 17);
            labelNewHeaderKey.Name = "labelNewHeaderKey";
            labelNewHeaderKey.Size = new Size(41, 24);
            labelNewHeaderKey.TabIndex = 0;
            labelNewHeaderKey.Text = "Key";
            // 
            // tabPageBody
            // 
            tabPageBody.Controls.Add(dataGridViewRequestBody);
            tabPageBody.Controls.Add(richTextBoxRequestBody);
            tabPageBody.Controls.Add(panelRequestBody);
            tabPageBody.Location = new Point(4, 33);
            tabPageBody.Name = "tabPageBody";
            tabPageBody.Padding = new Padding(3);
            tabPageBody.Size = new Size(1537, 387);
            tabPageBody.TabIndex = 3;
            tabPageBody.Text = "Body";
            tabPageBody.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRequestBody
            // 
            dataGridViewRequestBody.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRequestBody.Location = new Point(313, 90);
            dataGridViewRequestBody.Name = "dataGridViewRequestBody";
            dataGridViewRequestBody.RowHeadersWidth = 62;
            dataGridViewRequestBody.Size = new Size(316, 144);
            dataGridViewRequestBody.TabIndex = 5;
            dataGridViewRequestBody.UserAddedRow += dataGridViewRequestBody_UserAddedRow;
            dataGridViewRequestBody.UserDeletedRow += dataGridViewRequestBody_UserDeletedRow;
            dataGridViewRequestBody.KeyUp += dataGridViewRequestBody_KeyUp;
            // 
            // richTextBoxRequestBody
            // 
            richTextBoxRequestBody.Location = new Point(98, 90);
            richTextBoxRequestBody.Name = "richTextBoxRequestBody";
            richTextBoxRequestBody.Size = new Size(150, 144);
            richTextBoxRequestBody.TabIndex = 4;
            richTextBoxRequestBody.Text = "";
            // 
            // panelRequestBody
            // 
            panelRequestBody.Controls.Add(labelBodyBinaryFileFull);
            panelRequestBody.Controls.Add(labelBodyBinaryFile);
            panelRequestBody.Controls.Add(radioButtonBodyBinary);
            panelRequestBody.Controls.Add(radioButtonBodyRaw);
            panelRequestBody.Controls.Add(radioButtonBodyFormurlencoded);
            panelRequestBody.Controls.Add(radioButtonBodyFormData);
            panelRequestBody.Controls.Add(radioButtonBodyNone);
            panelRequestBody.Controls.Add(comboBoxRqeuestBodyDataType);
            panelRequestBody.Dock = DockStyle.Top;
            panelRequestBody.Location = new Point(3, 3);
            panelRequestBody.Name = "panelRequestBody";
            panelRequestBody.Size = new Size(1531, 60);
            panelRequestBody.TabIndex = 3;
            // 
            // labelBodyBinaryFileFull
            // 
            labelBodyBinaryFileFull.AutoSize = true;
            labelBodyBinaryFileFull.ForeColor = SystemColors.Highlight;
            labelBodyBinaryFileFull.Location = new Point(930, 18);
            labelBodyBinaryFileFull.Name = "labelBodyBinaryFileFull";
            labelBodyBinaryFileFull.Size = new Size(40, 24);
            labelBodyBinaryFileFull.TabIndex = 22;
            labelBodyBinaryFileFull.Text = "File";
            labelBodyBinaryFileFull.Visible = false;
            // 
            // labelBodyBinaryFile
            // 
            labelBodyBinaryFile.AutoSize = true;
            labelBodyBinaryFile.ForeColor = SystemColors.Highlight;
            labelBodyBinaryFile.Location = new Point(864, 18);
            labelBodyBinaryFile.Name = "labelBodyBinaryFile";
            labelBodyBinaryFile.Size = new Size(40, 24);
            labelBodyBinaryFile.TabIndex = 21;
            labelBodyBinaryFile.Text = "File";
            labelBodyBinaryFile.Visible = false;
            // 
            // radioButtonBodyBinary
            // 
            radioButtonBodyBinary.AutoSize = true;
            radioButtonBodyBinary.Location = new Point(741, 16);
            radioButtonBodyBinary.Name = "radioButtonBodyBinary";
            radioButtonBodyBinary.Size = new Size(90, 28);
            radioButtonBodyBinary.TabIndex = 20;
            radioButtonBodyBinary.TabStop = true;
            radioButtonBodyBinary.Text = "binary";
            radioButtonBodyBinary.UseVisualStyleBackColor = true;
            radioButtonBodyBinary.CheckedChanged += radioButtonBodyBinary_CheckedChanged;
            // 
            // radioButtonBodyRaw
            // 
            radioButtonBodyRaw.AutoSize = true;
            radioButtonBodyRaw.Location = new Point(633, 16);
            radioButtonBodyRaw.Name = "radioButtonBodyRaw";
            radioButtonBodyRaw.Size = new Size(66, 28);
            radioButtonBodyRaw.TabIndex = 19;
            radioButtonBodyRaw.TabStop = true;
            radioButtonBodyRaw.Text = "raw";
            radioButtonBodyRaw.UseVisualStyleBackColor = true;
            radioButtonBodyRaw.CheckedChanged += radioButtonBodyRaw_CheckedChanged;
            // 
            // radioButtonBodyFormurlencoded
            // 
            radioButtonBodyFormurlencoded.AutoSize = true;
            radioButtonBodyFormurlencoded.Location = new Point(337, 16);
            radioButtonBodyFormurlencoded.Name = "radioButtonBodyFormurlencoded";
            radioButtonBodyFormurlencoded.Size = new Size(249, 28);
            radioButtonBodyFormurlencoded.TabIndex = 18;
            radioButtonBodyFormurlencoded.TabStop = true;
            radioButtonBodyFormurlencoded.Text = "x-www-form-urlencoded";
            radioButtonBodyFormurlencoded.UseVisualStyleBackColor = true;
            radioButtonBodyFormurlencoded.CheckedChanged += radioButtonBodyFormurlencoded_CheckedChanged;
            // 
            // radioButtonBodyFormData
            // 
            radioButtonBodyFormData.AutoSize = true;
            radioButtonBodyFormData.Location = new Point(167, 16);
            radioButtonBodyFormData.Name = "radioButtonBodyFormData";
            radioButtonBodyFormData.Size = new Size(123, 28);
            radioButtonBodyFormData.TabIndex = 17;
            radioButtonBodyFormData.TabStop = true;
            radioButtonBodyFormData.Text = "form-data";
            radioButtonBodyFormData.UseVisualStyleBackColor = true;
            radioButtonBodyFormData.CheckedChanged += radioButtonBodyFormData_CheckedChanged;
            // 
            // radioButtonBodyNone
            // 
            radioButtonBodyNone.AutoSize = true;
            radioButtonBodyNone.Checked = true;
            radioButtonBodyNone.Location = new Point(38, 16);
            radioButtonBodyNone.Name = "radioButtonBodyNone";
            radioButtonBodyNone.Size = new Size(82, 28);
            radioButtonBodyNone.TabIndex = 16;
            radioButtonBodyNone.TabStop = true;
            radioButtonBodyNone.Text = "None";
            radioButtonBodyNone.UseVisualStyleBackColor = true;
            radioButtonBodyNone.CheckedChanged += radioButtonBodyNone_CheckedChanged;
            // 
            // comboBoxRqeuestBodyDataType
            // 
            comboBoxRqeuestBodyDataType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRqeuestBodyDataType.FormattingEnabled = true;
            comboBoxRqeuestBodyDataType.Items.AddRange(new object[] { "Json", "Text", "Html", "Xml", "JavaScript" });
            comboBoxRqeuestBodyDataType.Location = new Point(864, 15);
            comboBoxRqeuestBodyDataType.Name = "comboBoxRqeuestBodyDataType";
            comboBoxRqeuestBodyDataType.Size = new Size(270, 32);
            comboBoxRqeuestBodyDataType.TabIndex = 15;
            comboBoxRqeuestBodyDataType.Visible = false;
            // 
            // tabPageRequestDetails
            // 
            tabPageRequestDetails.Controls.Add(treeViewRequestDetails);
            tabPageRequestDetails.Location = new Point(4, 33);
            tabPageRequestDetails.Name = "tabPageRequestDetails";
            tabPageRequestDetails.Padding = new Padding(3);
            tabPageRequestDetails.Size = new Size(1537, 387);
            tabPageRequestDetails.TabIndex = 4;
            tabPageRequestDetails.Text = "Details";
            tabPageRequestDetails.UseVisualStyleBackColor = true;
            // 
            // treeViewRequestDetails
            // 
            treeViewRequestDetails.Dock = DockStyle.Fill;
            treeViewRequestDetails.Location = new Point(3, 3);
            treeViewRequestDetails.Name = "treeViewRequestDetails";
            treeViewRequestDetails.Size = new Size(1531, 381);
            treeViewRequestDetails.TabIndex = 0;
            // 
            // contextMenuStripProject
            // 
            contextMenuStripProject.ImageScalingSize = new Size(24, 24);
            contextMenuStripProject.Items.AddRange(new ToolStripItem[] { newToolStripMenuItem, renameProjectToolStripMenuItem, deleteProjectToolStripMenuItem, toolStripMenuItemRestoreProject, toolStripMenuItemClearProject });
            contextMenuStripProject.Name = "contextMenuStripProject";
            contextMenuStripProject.Size = new Size(216, 154);
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(215, 30);
            newToolStripMenuItem.Text = "New Group";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // renameProjectToolStripMenuItem
            // 
            renameProjectToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripTextBoxProjectName, toolStripMenuItemSetProjectName });
            renameProjectToolStripMenuItem.Name = "renameProjectToolStripMenuItem";
            renameProjectToolStripMenuItem.Size = new Size(215, 30);
            renameProjectToolStripMenuItem.Text = "Rename Project";
            // 
            // toolStripTextBoxProjectName
            // 
            toolStripTextBoxProjectName.BorderStyle = BorderStyle.FixedSingle;
            toolStripTextBoxProjectName.Name = "toolStripTextBoxProjectName";
            toolStripTextBoxProjectName.Size = new Size(200, 30);
            // 
            // toolStripMenuItemSetProjectName
            // 
            toolStripMenuItemSetProjectName.Name = "toolStripMenuItemSetProjectName";
            toolStripMenuItemSetProjectName.Size = new Size(290, 34);
            toolStripMenuItemSetProjectName.Text = "Save";
            toolStripMenuItemSetProjectName.Click += toolStripMenuItemSetProjectName_Click;
            // 
            // deleteProjectToolStripMenuItem
            // 
            deleteProjectToolStripMenuItem.Name = "deleteProjectToolStripMenuItem";
            deleteProjectToolStripMenuItem.Size = new Size(215, 30);
            deleteProjectToolStripMenuItem.Text = "Delete Project";
            deleteProjectToolStripMenuItem.Click += deleteProjectToolStripMenuItem_Click;
            // 
            // toolStripMenuItemRestoreProject
            // 
            toolStripMenuItemRestoreProject.Name = "toolStripMenuItemRestoreProject";
            toolStripMenuItemRestoreProject.Size = new Size(215, 30);
            toolStripMenuItemRestoreProject.Text = "Restore Project";
            toolStripMenuItemRestoreProject.Visible = false;
            toolStripMenuItemRestoreProject.Click += toolStripMenuItemRestoreProject_Click;
            // 
            // toolStripMenuItemClearProject
            // 
            toolStripMenuItemClearProject.Name = "toolStripMenuItemClearProject";
            toolStripMenuItemClearProject.Size = new Size(215, 30);
            toolStripMenuItemClearProject.Text = "Clear Project";
            toolStripMenuItemClearProject.Click += toolStripMenuItemClearProject_Click;
            // 
            // contextMenuStripGroup
            // 
            contextMenuStripGroup.ImageScalingSize = new Size(24, 24);
            contextMenuStripGroup.Items.AddRange(new ToolStripItem[] { newRequestToolStripMenuItem, renameGroupToolStripMenuItem, deleteGroupToolStripMenuItem, toolStripMenuItemRestoreGroup, toolStripMenuItemClearGroup, toolStripSeparator3, toolStripMenuItemPasteToGroup });
            contextMenuStripGroup.Name = "contextMenuStripGroup";
            contextMenuStripGroup.Size = new Size(210, 190);
            contextMenuStripGroup.Click += contextMenuStripGroup_Click;
            // 
            // newRequestToolStripMenuItem
            // 
            newRequestToolStripMenuItem.Name = "newRequestToolStripMenuItem";
            newRequestToolStripMenuItem.Size = new Size(209, 30);
            newRequestToolStripMenuItem.Text = "New Request";
            newRequestToolStripMenuItem.Click += newRequestToolStripMenuItem_Click;
            // 
            // renameGroupToolStripMenuItem
            // 
            renameGroupToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripTextBoxGroupName, toolStripMenuItemSaveGroupName });
            renameGroupToolStripMenuItem.Name = "renameGroupToolStripMenuItem";
            renameGroupToolStripMenuItem.Size = new Size(209, 30);
            renameGroupToolStripMenuItem.Text = "Rename Group";
            // 
            // toolStripTextBoxGroupName
            // 
            toolStripTextBoxGroupName.BorderStyle = BorderStyle.FixedSingle;
            toolStripTextBoxGroupName.Name = "toolStripTextBoxGroupName";
            toolStripTextBoxGroupName.Size = new Size(200, 30);
            // 
            // toolStripMenuItemSaveGroupName
            // 
            toolStripMenuItemSaveGroupName.Name = "toolStripMenuItemSaveGroupName";
            toolStripMenuItemSaveGroupName.Size = new Size(290, 34);
            toolStripMenuItemSaveGroupName.Text = "Save";
            toolStripMenuItemSaveGroupName.Click += toolStripMenuItemSaveGroupName_Click;
            // 
            // deleteGroupToolStripMenuItem
            // 
            deleteGroupToolStripMenuItem.Name = "deleteGroupToolStripMenuItem";
            deleteGroupToolStripMenuItem.Size = new Size(209, 30);
            deleteGroupToolStripMenuItem.Text = "Delete Group";
            deleteGroupToolStripMenuItem.Click += deleteGroupToolStripMenuItem_Click;
            // 
            // toolStripMenuItemRestoreGroup
            // 
            toolStripMenuItemRestoreGroup.Name = "toolStripMenuItemRestoreGroup";
            toolStripMenuItemRestoreGroup.Size = new Size(209, 30);
            toolStripMenuItemRestoreGroup.Text = "Restore Group";
            toolStripMenuItemRestoreGroup.Visible = false;
            // 
            // toolStripMenuItemClearGroup
            // 
            toolStripMenuItemClearGroup.Name = "toolStripMenuItemClearGroup";
            toolStripMenuItemClearGroup.Size = new Size(209, 30);
            toolStripMenuItemClearGroup.Text = "Clear Group";
            toolStripMenuItemClearGroup.Click += toolStripMenuItemClearGroup_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(206, 6);
            // 
            // toolStripMenuItemPasteToGroup
            // 
            toolStripMenuItemPasteToGroup.Name = "toolStripMenuItemPasteToGroup";
            toolStripMenuItemPasteToGroup.Size = new Size(209, 30);
            toolStripMenuItemPasteToGroup.Text = "Paste";
            toolStripMenuItemPasteToGroup.Visible = false;
            toolStripMenuItemPasteToGroup.Click += toolStripMenuItemPasteToGroup_Click;
            // 
            // contextMenuStripHttpRequestInfo
            // 
            contextMenuStripHttpRequestInfo.ImageScalingSize = new Size(24, 24);
            contextMenuStripHttpRequestInfo.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemcopyRequestInfo, toolStripMenuItemPasteRequestInfo, ToolStripMenuItemduplicateRequestInfo, deleteToolStripMenuItem, toolStripMenuItemRestoreRequest, toolStripMenuItemClearRequest });
            contextMenuStripHttpRequestInfo.Name = "contextMenuStripHttpRequestInfo";
            contextMenuStripHttpRequestInfo.Size = new Size(164, 184);
            // 
            // ToolStripMenuItemcopyRequestInfo
            // 
            ToolStripMenuItemcopyRequestInfo.Name = "ToolStripMenuItemcopyRequestInfo";
            ToolStripMenuItemcopyRequestInfo.Size = new Size(163, 30);
            ToolStripMenuItemcopyRequestInfo.Text = "Copy";
            ToolStripMenuItemcopyRequestInfo.Click += ToolStripMenuItemcopyRequestInfo_Click;
            // 
            // toolStripMenuItemPasteRequestInfo
            // 
            toolStripMenuItemPasteRequestInfo.Enabled = false;
            toolStripMenuItemPasteRequestInfo.Name = "toolStripMenuItemPasteRequestInfo";
            toolStripMenuItemPasteRequestInfo.Size = new Size(163, 30);
            toolStripMenuItemPasteRequestInfo.Text = "Paste";
            toolStripMenuItemPasteRequestInfo.Click += toolStripMenuItemPasteRequestInfo_Click;
            // 
            // ToolStripMenuItemduplicateRequestInfo
            // 
            ToolStripMenuItemduplicateRequestInfo.Name = "ToolStripMenuItemduplicateRequestInfo";
            ToolStripMenuItemduplicateRequestInfo.Size = new Size(163, 30);
            ToolStripMenuItemduplicateRequestInfo.Text = "Duplicate";
            ToolStripMenuItemduplicateRequestInfo.Click += ToolStripMenuItemduplicateRequestInfo_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(163, 30);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // toolStripMenuItemRestoreRequest
            // 
            toolStripMenuItemRestoreRequest.Name = "toolStripMenuItemRestoreRequest";
            toolStripMenuItemRestoreRequest.Size = new Size(163, 30);
            toolStripMenuItemRestoreRequest.Text = "Restore";
            toolStripMenuItemRestoreRequest.Visible = false;
            toolStripMenuItemRestoreRequest.Click += toolStripMenuItemRestoreRequest_Click;
            // 
            // toolStripMenuItemClearRequest
            // 
            toolStripMenuItemClearRequest.Name = "toolStripMenuItemClearRequest";
            toolStripMenuItemClearRequest.Size = new Size(163, 30);
            toolStripMenuItemClearRequest.Text = "Clear";
            toolStripMenuItemClearRequest.Click += toolStripMenuItemClearRequest_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2051, 1173);
            Controls.Add(panelWorkspace);
            Controls.Add(tabControlMain);
            Controls.Add(menuStripMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStripMain;
            Name = "FormMain";
            Text = "OpenPost";
            FormClosing += FormMain_FormClosing;
            menuStripMain.ResumeLayout(false);
            menuStripMain.PerformLayout();
            tabControlMain.ResumeLayout(false);
            tabPageProject.ResumeLayout(false);
            panelWorkspace.ResumeLayout(false);
            tabControlHttpResponse.ResumeLayout(false);
            tabPageResponseOverview.ResumeLayout(false);
            tabPageResponseBody.ResumeLayout(false);
            tabControlResponseBodyView.ResumeLayout(false);
            tabPageResponseBodyInText.ResumeLayout(false);
            tabPageResponseBodyInHTML.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webView2ResponseBodyInHTML).EndInit();
            tabPageResponseBodyInHex.ResumeLayout(false);
            tabControlHttpRequest.ResumeLayout(false);
            tabPageRequest.ResumeLayout(false);
            tabPageRequest.PerformLayout();
            groupBoxRequestParams.ResumeLayout(false);
            panelRequestParameter.ResumeLayout(false);
            panelRequestParameter.PerformLayout();
            tabPageHeader.ResumeLayout(false);
            panelRequestHeader.ResumeLayout(false);
            panelRequestHeader.PerformLayout();
            tabPageBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewRequestBody).EndInit();
            panelRequestBody.ResumeLayout(false);
            panelRequestBody.PerformLayout();
            tabPageRequestDetails.ResumeLayout(false);
            contextMenuStripProject.ResumeLayout(false);
            contextMenuStripGroup.ResumeLayout(false);
            contextMenuStripHttpRequestInfo.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStripMain;
        private ToolStripMenuItem toolStripMenuItemSolution;
        private ToolStripMenuItem toolStripMenuItemFlow;
        private TabControl tabControlMain;
        private TabPage tabPageProject;
        private TabPage tabPageFlow;
        private TreeView treeViewProjects;
        private Panel panelWorkspace;
        private TabControl tabControlHttpResponse;
        private TabPage tabPageResponseBody;
        private TabControl tabControlHttpRequest;
        private TabPage tabPageRequest;
        private TabPage tabPageHeader;
        private TabPage tabPageBody;
        private Label labelRequestName;
        private TextBox textBoxRequestDescription;
        private Label labelRequestDescription;
        private TextBox textBoxRequestName;
        private ComboBox comboBoxRequestMethod;
        private Label labelRequestMethod;
        private TextBox textBoxRequestURL;
        private Label labelRequestURL;
        private Button buttonRequestSave;
        private Button buttonRequestQuery;
        private Label labelRequestPath;
        private ContextMenuStrip contextMenuStripProject;
        private ContextMenuStrip contextMenuStripGroup;
        private ContextMenuStrip contextMenuStripHttpRequestInfo;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem renameProjectToolStripMenuItem;
        private ToolStripMenuItem newRequestToolStripMenuItem;
        private ToolStripMenuItem renameGroupToolStripMenuItem;
        private ToolStripMenuItem ToolStripMenuItemcopyRequestInfo;
        private ToolStripMenuItem ToolStripMenuItemduplicateRequestInfo;
        private ToolStripTextBox toolStripTextBoxProjectName;
        private ToolStripMenuItem toolStripMenuItemSetProjectName;
        private ToolStripMenuItem openToolStripMenuItemNewSolution;
        private ToolStripMenuItem openToolStripMenuItemOpenSolution;
        private ToolStripMenuItem saveToolStripMenuItemSaveSolution;
        private ToolStripMenuItem saveAsToolStripMenuItemSaveasSolution;
        private Panel panelRequestHeader;
        private ListView listViewRequestHeader;
        private Panel panelRequestBody;
        private ComboBox comboBoxRqeuestBodyDataType;
        private Label labelRequestBodyDataType;
        private ToolStripTextBox toolStripTextBoxGroupName;
        private ToolStripMenuItem toolStripMenuItemSaveGroupName;
        private ToolStripMenuItem toolStripMenuItemPasteRequestInfo;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItemNewProject;
        private ToolStripMenuItem toolStripMenuItemNewFlow;
        private TextBox textBoxNewHeaderKey;
        private Label labelNewHeaderKey;
        private Button buttonNewHeaderAdd;
        private TextBox textBoxNewHeaderValue;
        private Label labelNewHeaderValue;
        private TabPage tabPageResponseOverview;
        private TreeView treeViewResponse;
        private TabControl tabControlResponseBodyView;
        private TabPage tabPageResponseBodyInText;
        private TabPage tabPageResponseBodyInHTML;
        private TabPage tabPageResponseBodyInHex;
        private RichTextBox richTextBoxResponseBodyInText;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2ResponseBodyInHTML;
        private RichTextBox richTextBoxResponseBodyInHex;
        private ListView listViewQueryHistory;
        private ColumnHeader ColumnHeaderHistory;
        private ToolStripMenuItem deleteProjectToolStripMenuItem;
        private ToolStripMenuItem deleteGroupToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem toolStripMenuItemViewAll;
        private ToolStripMenuItem toolStripMenuItemClearDeleted;
        private ToolStripMenuItem toolStripMenuItemRestoreProject;
        private ToolStripMenuItem toolStripMenuItemRestoreGroup;
        private ToolStripMenuItem toolStripMenuItemRestoreRequest;
        private ToolStripMenuItem toolStripMenuItemClearProject;
        private ToolStripMenuItem toolStripMenuItemClearGroup;
        private ToolStripMenuItem toolStripMenuItemClearRequest;
        private RadioButton radioButtonBodyNone;
        private RadioButton radioButtonBodyBinary;
        private RadioButton radioButtonBodyRaw;
        private RadioButton radioButtonBodyFormurlencoded;
        private RadioButton radioButtonBodyFormData;
        private Label labelBodyBinaryFile;
        private DataGridView dataGridViewRequestBody;
        private RichTextBox richTextBoxRequestBody;
        private Label labelBodyBinaryFileFull;
        private TabPage tabPageRequestDetails;
        private TreeView treeViewRequestDetails;
        private GroupBox groupBoxRequestParams;
        private ListView listViewRequestParameter;
        private Panel panelRequestParameter;
        private Button buttonNewParamAdd;
        private TextBox textBoxNewParamValue;
        private Label labelNewParamValue;
        private TextBox textBoxNewParamKey;
        private Label labelNewParamKey;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem toolStripMenuItemPasteToGroup;
    }
}
