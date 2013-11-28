using System;
using MarkdownSharp;
using Tamarack.Pipeline;

namespace Demo.OutputRendering.CommandUI.Filters
{
    public class ConvertToHtml : IFilter<Context, bool>
    {
        public bool Execute(Context context, Func<Context, bool> executeNext)
        {
            context.Content = new Markdown().Transform(context.Content);
            return executeNext(context);
        }
    }
}