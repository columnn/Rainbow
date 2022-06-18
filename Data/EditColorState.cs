namespace Rainbow;

public class EditColorState
{
    public bool ShowingConfigureDialog { get; private set; }
    public Color? EditingColor { get; private set; }

    public void ShowEditColorDialog(Color color)
    {
        EditingColor = new Color()
        {
            ColorId = color.ColorId,
            Name = color.Name,
            Hex = color.Hex,
            Username = color.Username
        };

        ShowingConfigureDialog = true;
    }

    public void CancelColorEdit()
    {
        ShowingConfigureDialog = false;
        EditingColor = null;
    }

    public void EditColor()
    {
        EditingColor = null;
        ShowingConfigureDialog = false;
    }
}