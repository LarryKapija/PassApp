using System;
using MonkeyCache.FileStore;
using PassApp.Services.Interfaces;

namespace PassApp.Services.Implementation
{
	public class MonkeyCacheService : ICacheService
	{
		public MonkeyCacheService()
		{
			Barrel.ApplicationId = Xamarin.Essentials.AppInfo.Name;
		} 
	}
}