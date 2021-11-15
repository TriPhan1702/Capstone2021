namespace HairCutAppAPI.Utilities.Notification
{
    public interface IPushNotification
    {
        void Push(string deviceToken, string title, string body, string screen, object data);
    }
}