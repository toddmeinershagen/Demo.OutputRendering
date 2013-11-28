using System;
using System.IO;
using Tamarack.Pipeline;

namespace Demo.OutputRendering.CommandUI.Filters
{
    public class ObtainMarkdown : IFilter<Context, bool>
    {
        public bool Execute(Context context, Func<Context, bool> executeNext)
        {
            var filePath = string.Format("{0}.md", context.TemplateId);
            context.Content = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, filePath));
            return executeNext(context);
        }
    }
}