using System;
using PassApp.Utils;
using Firebase.Database;
using PassApp.Services.Interfaces;
using System.Threading.Tasks;
using PassApp.Models;
using Firebase.Database.Query;
using Firebase.Database.Streaming;

namespace PassApp.Services.Implementation
{
	public class RealTimeDBService : ICloudDBService
	{
		private readonly FirebaseClient _firebaseClient;

		public RealTimeDBService()
        {
			_firebaseClient = new FirebaseClient(Constants.Firebase.ApiKey);
        }

        public async Task PostPassword(Password password)
        {
            await _firebaseClient.Child("Password").PostAsync(password);
        }

        public IObservable<FirebaseEvent<Password>> GetPasswords()
        {
           return _firebaseClient.Child("Password")
                .AsObservable<Password>();
        }
    }
}

