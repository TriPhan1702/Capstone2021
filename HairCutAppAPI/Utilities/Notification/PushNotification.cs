using System;
using System.IO;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Html;
using Newtonsoft.Json;

namespace HairCutAppAPI.Utilities.Notification
{
    public class PushNotification : IPushNotification
    {
        public async void Push(string deviceToken, string title, string body, string screen, object data)
        {
            try
            {    
                var applicationID = "AAAA8-N5Dnk:APA91bFjvbPNga7NDSsMYPHfa6o5OIzTM64WUn9CLct1-7lybapkewfwc-PrsrSiOwxCy1J-L5OTPcEasvmmc8lqNlgaZ_7Xv6ap-gkOeyZEZL_3l-HgtRgLsmxn5N6sp5xe1IqCtOVq";

                var senderId = "1047493414521";

                var tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");

                tRequest.Method = "post";

                tRequest.ContentType = "application/json";

                var notiData = new

                {

                    to = deviceToken,

                    notification = new

                    {
                        body, title
                        // icon = ""
                    }    ,
                    data = new
                    {
                        screen,
                        data
                    }
                };       

                var json = JsonConvert.SerializeObject(notiData);

                var byteArray = Encoding.UTF8.GetBytes(json);

                tRequest.Headers.Add($"Authorization: key={applicationID}");

                tRequest.Headers.Add($"Sender: id={senderId}");

                tRequest.ContentLength = byteArray.Length;


                await using var dataStream = await tRequest.GetRequestStreamAsync();
                await dataStream.WriteAsync(byteArray, 0, byteArray.Length);


                using var tResponse = await tRequest.GetResponseAsync();
                await using var dataStreamResponse = tResponse.GetResponseStream();
                using var tReader = new StreamReader(dataStreamResponse);
                var sResponseFromServer = await tReader.ReadToEndAsync();

                // var str = sResponseFromServer;
            }        

            catch (Exception ex)
            {
                //TODO:Log
                var str = ex.Message;
            }          
        }
    }
}