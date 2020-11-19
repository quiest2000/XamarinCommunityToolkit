﻿using System;
using System.Threading.Tasks;
using NSubstitute;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Xamarin.Forms;
using Xunit;

namespace Xamarin.CommunityToolkit.UnitTests.Views
{
	public class SnackBar_Tests
	{
#if !NETCOREAPP
		[Fact]
		public async void PageExtension_DisplaySnackBarAsync_PlatformNotSupportedException()
		{
			var page = new ContentPage();
			await Assert.ThrowsAsync<PlatformNotSupportedException>(() => page.DisplaySnackBarAsync(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<Func<Task>>()));
		}

		[Fact]
		public async void PageExtension_DisplaySnackBarAsyncWithOptions_PlatformNotSupportedException()
		{
			var page = new ContentPage();
			await Assert.ThrowsAsync<PlatformNotSupportedException>(() => page.DisplaySnackBarAsync(Arg.Any<SnackBarOptions>()));
		}

		[Fact]
		public async void PageExtension_DisplayToastAsync_PlatformNotSupportedException()
		{
			var page = new ContentPage();
			await Assert.ThrowsAsync<PlatformNotSupportedException>(() => page.DisplayToastAsync("message"));
		}

		[Fact]
		public async void PageExtension_DisplayToastAsyncWithOptions_PlatformNotSupportedException()
		{
			var page = new ContentPage();
			await Assert.ThrowsAsync<PlatformNotSupportedException>(() => page.DisplayToastAsync(Arg.Any<ToastOptions>()));
		}
#endif
	}
}