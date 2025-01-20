using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OpenPostLib.Core
{
    public abstract class Condition : Node
    {
        public const string Positive = "true";
        public const string Negative = "false";
        protected Condition(Action parentAction, Action tAction, Action nAction)
        {
            Parent = parentAction;
            SubNodes.Add(Positive, tAction);
            SubNodes.Add(Negative, nAction);
        }

        public abstract Task<Action?> EvaluateAsync();
    }

    public class RegexCondition : Condition
    {
        public string RegexPattern { get; set; }

        public RegexCondition(Action input, string regex, Action pAction, Action nAction)
            : base(input, pAction, nAction)
        {
            RegexPattern = regex;
        }

        public override async Task<Action?> EvaluateAsync()
        {
            //check parent action's Response content, if it's null, return negative action
            if (Parent == null || !(Parent is Action parentAction) || parentAction.Response == null)
            {
                return Route(Negative) as Action;
            }

            var content = await parentAction.Response.GetContentAsStringAsync();

            if (!string.IsNullOrEmpty(content) && Regex.IsMatch(content, RegexPattern))
            {
                return Route(Positive) as Action;
            }
            return Route(Negative) as Action;
        }
    }
}