namespace HairCutAppAPI.Utilities.Notification
{
    public interface IPushNotification
    {
        void Push(string deviceId, string title, string body);
    }
}