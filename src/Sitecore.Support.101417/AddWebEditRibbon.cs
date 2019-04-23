using System.IO;
using System.Web;
using Sitecore.Diagnostics;
using Sitecore.ExperienceEditor.Pipelines.GetExperienceEditorRibbon;
using Sitecore.Mvc.ExperienceEditor.Pipelines.RenderPageExtenders;
using Sitecore.Web.UI;

namespace Sitecore.Support.Mvc.ExperienceEditor.Pipelines.RenderPageExtenders.SpeakRibbon
{
  public class RenderPageEditorSpeakExtender : RenderPageExtendersProcessor
  {
    protected override bool Render(TextWriter writer)
    {
      try
      {
        Assert.ArgumentNotNull(writer, "writer");
        GetExperienceEditorRibbonArgs expr_10 = new GetExperienceEditorRibbonArgs();
        ExecuteGetExperienceEditorRibbon.Run(expr_10);
        var webControl = expr_10.Control as WebControl;
        if (webControl == null)
          return false;
        writer.Write(webControl.RenderAsText());
        return true;
      }
      catch (System.Web.HttpException ex)
      {

      }
      return false;
    }

  }
}