using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using Sitecore.Configuration;
using Sitecore.Pipelines;
using Sitecore.Shell.Web;
using Sitecore.Sites;

namespace Sitecore.Support.Mvc.Pipelines.Request.RequestBegin
{

  public class EnsureLoggedInForPreview
  {
    [SuppressMessage("Microsoft.Performance", "CA1822:Mark members as static", Justification = "This will introduce breaking changes.")]
    public void Process(PipelineArgs args)
    {
      if (!Context.PageMode.IsNormal && !Context.IsLoggedIn)
      {
        SiteContext site = Factory.GetSite("shell");
        using (new SiteContextSwitcher(site))
        {
          HttpContext.Current.Response.Redirect("/sitecore/login", true); // 101417 SXA fix. Redirect without using ShellPage.IsLoggedIn() instead of original patch's not redirecting at all.
        }
      }
    }
  }

}