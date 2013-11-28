using System;
using Demo.OutputRendering.CommandUI.Filters;
using Tamarack.Pipeline;

namespace Demo.OutputRendering.CommandUI
{
    public class Service
    {
        public void Execute()
        {
            var renderer = new PdfRenderer();

            var pipeline = new Pipeline<Context, bool>()
                .Add<ObtainMarkdown>()
                .Add<ConvertToHtml>()
                .Finally(renderer.Render);

            var templateId = new Guid("29e30783-e23e-4fa8-b513-2248feb8b6e4");
            var context = new Context {TemplateId = templateId};
            pipeline.Execute(context);
        }
    }
}