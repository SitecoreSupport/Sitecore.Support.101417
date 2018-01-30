namespace Sitecore.Support.LaunchPad
{
  using Sitecore.Configuration;
  using Sitecore.LaunchPad.Configuration;
  using Sitecore.Shell.Web;
  using Sitecore.Xdb.Configuration;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web;
  public class LaunchPad : Sitecore.LaunchPad.LaunchPad
  {
    public override void Initialize()
    {
      var coreDb = Context.Database;

      var chart1Layout = coreDb.GetItem("{FA046F20-75A5-4C7F-9FEC-FAC6EEAC33D7}");
      var chart2Layout = coreDb.GetItem("{7431DE4F-C65B-4CBC-B5BA-FD99E1931AE9}");

      if (FallBackMessage != null)
      {
        var text = this.FallBackMessage.Item["Text"];
        FallBackMessage.Parameters["Text"] = text.Replace("{{version}}", About.GetVersionNumber(false));
      }

      if (Text2 != null && !XdbSettings.Enabled)
      {
        Text2.DataSource = "{C2F629FF-BD7D-42B4-A247-3380DAE1408C}";
      }

      if (!LaunchPadSettings.EnablePersonalizedFrames || !XdbSettings.Enabled || chart1Layout == null || chart2Layout == null)
      {
        RowPanelTilesWrapper.Parameters["IsVisible"] = "false";
        InteractionChartApp.Placeholder = string.Empty;
        InteractionChartApp.DataSource = "{AFE511E0-249F-47AF-8439-4E3641DAFAB8}";
        CampaignsChartApp.Placeholder = string.Empty;
        CampaignsChartApp.DataSource = "{AFE511E0-249F-47AF-8439-4E3641DAFAB8}";
      }
    }
  }
}