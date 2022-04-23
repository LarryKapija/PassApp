using System;
using System.Threading.Tasks;
using Firebase.Database.Streaming;
using PassApp.Models;
using Refit;

namespace PassApp.Services.Interfaces
{
	public interface ICloudDBService
	{
		Task PostPassword(Password password);

		IObservable<FirebaseEvent<Password>> GetPasswords();
	}
}

