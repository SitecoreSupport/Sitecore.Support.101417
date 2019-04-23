namespace Sitecore.Support.XA.Feature.StickyNotes.Pipelines.GetChromeData
{
// AddStickyNotesButton
  using Sitecore.Pipelines.GetChromeData;

  public class
    AddStickyNotesButton : Sitecore.XA.Feature.StickyNotes.Pipelines.GetChromeData.AddStickyNotesButton
  {
    public override void Process(GetChromeDataArgs args)
    {
      if (!Context.PageMode.IsNormal && !Context.IsLoggedIn)
      {
        // 101417 SXA fix. Do nothing if user is not logged in, in conjunction with EnsureLoggedInForPreview.
        // this prevents a "System.ArgumentNullException... Value cannot be null. Parameter name: buttonItem"
      }
      else
      {
        base.Process(args);
      }
    }
  }
}