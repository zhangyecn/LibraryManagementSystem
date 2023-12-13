namespace LibraryManagementSystem;

public enum MediaType
{
    Cd = 0,
    Dvd,
    BlueRay
}

public class MultiMediaItem : Item
{
    public ICollection<MultiMediaRecord> Tracks { get; set; }
    public MediaType Media { get; set; }
}