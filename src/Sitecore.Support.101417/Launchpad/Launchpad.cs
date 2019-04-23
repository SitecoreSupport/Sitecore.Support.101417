namespace Sitecore.Support.LaunchPad
{
  // LaunchPad
  using Sitecore;
  using Sitecore.Configuration;
  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.LaunchPad;
  using Sitecore.LaunchPad.Configuration;
  using Sitecore.Speak.Applications.Dependencies;

  public class LaunchPad : Sitecore.LaunchPad.LaunchPad
  {
    public override void Initialize()
    {
      Database database = Context.Database;
      Item item = database.GetItem("{FA046F20-75A5-4C7F-9FEC-FAC6EEAC33D7}");
      Item item2 = database.GetItem("{7431DE4F-C65B-4CBC-B5BA-FD99E1931AE9}");
      if (base.FallBackMessage != null)
      {
        string text = base.FallBackMessage.Item["Text"];
        base.FallBackMessage.Parameters["Text"] = text.Replace("{{version}}", About.GetVersionNumber(false));
      }
      Product product = AppDependencyManager.RegisteredProducts["xdb"];
      bool flag = product != null && product.IsEnabled();
      if (base.Text2 != null && !flag)
      {
        base.Text2.DataSource = "{C2F629FF-BD7D-42B4-A247-3380DAE1408C}";
      }
      if (!LaunchPadSettings.EnablePersonalizedFrames || !flag || item == null || item2 == null)
      {
        base.RowPanelTilesWrapper.Parameters["IsVisible"] = "false";
        base.InteractionChartApp.Placeholder = string.Empty;
        base.InteractionChartApp.DataSource = "{AFE511E0-249F-47AF-8439-4E3641DAFAB8}";
        base.CampaignsChartApp.Placeholder = string.Empty;
        base.CampaignsChartApp.DataSource = "{AFE511E0-249F-47AF-8439-4E3641DAFAB8}";
      }
    }
  }

}