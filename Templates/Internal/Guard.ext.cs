using System;
using System.Collections.Generic;
using System.Text;

namespace Aikixd.CodeGeneration.TemplatesT4.Templates.Internal
{
    partial class Guard
    {
        protected string Condition { get; }
        protected string Reaction { get; }

        public Guard(string condition, string reaction)
        {
            this.Condition = condition;
            this.Reaction = reaction;
        }
    }
}
