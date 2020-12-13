[<img src="https://raw.githubusercontent.com/dotnet-foundation/swag/master/logo/dotnetfoundation_v4.svg" alt=".NET Foundation" width=100>](https://dotnetfoundation.org)

<img src="assets/XamarinCommunityToolkit_128x128.png" width="64" /> Xamarin Community Toolkit
===========
Members of the community are rebooting this library under the guidance of the Xamarin team. The Xamarin Community Toolkit is a collection of common elements for mobile development with Xamarin.Forms that people tend to replicate across multiple apps. It simplifies and demonstrates common developer tasks when building apps with Xamarin.Forms. If you're looking for the historical code to reference, please check the **legacy** branch.

## Build Status

If you like to live dangerously (and while we are preparing our v1), you can use our [nightly](https://pkgs.dev.azure.com/xamarin/public/_packaging/XamarinCommunityToolkitNightly/nuget/v3/index.json) feed to try out packages right now.

| Build Server | Type         | Platform | Status |
|--------------|--------------|----------|--------|
| Azure DevOps         | Build        | Windows & Mac  | [![Build Status](https://dev.azure.com/xamarin/public/_apis/build/status/xamarin/CommunityToolkit/xamarin.XamarinCommunityToolkit%20(Public)?branchName=main)](https://dev.azure.com/xamarin/public/_build?definitionId=55&_a=summary)                                                  |

## Sample App

Browsing the [sample app](./src/CommunityToolkit/Xamarin.CommunityToolkit.Sample) is the best place to start exploring what's available today. 

## Installation

The toolkit is available via NuGet, and should be installed into all your projects:

* NuGet Official Releases: [![NuGet](https://img.shields.io/nuget/vpre/Xamarin.CommunityToolkit.svg?label=NuGet)](https://www.nuget.org/packages/Xamarin.CommunityToolkit/)
* NuGet Nightly Releases: [![NuGet Nightly](https://img.shields.io/badge/NuGet-Nightly-yellow)](https://pkgs.dev.azure.com/xamarin/public/_packaging/XamarinCommunityToolkitNightly/nuget/v3/index.json)

Now all you need to do is use it! 

## Documentation

### Toast

There are 2 different ways to use Toast.
1. On your Page call the method: 
```csharp
await MyPage.DisplayToastAsync(message, duration);
```
where `message` is your text, and duration is optional parameter. Default duration = 3000;

2. For advanced settings:
```csharp
    var messageOptions = new MessageOptions
    {
        Foreground = Color.Black,
        Font = Font.OfSize("Arial", 14),
        Message = "My text"
    };
    var options = new ToastOptions
    {
        MessageOptions = messageOptions,
        Duration = 3000,
        BackgroundColor = Color.Default,
        IsRtl = false,
    };
    await this.DisplayToastAsync(options);
```

### Snackbar

Snackbar has API which is similar to the Toast.
1. On your Page call the method: 
```csharp
var result = await MyPage.DisplaySnackbarAsync(message, actionButtonText, action, duration);
```
where `message` is your text, `actionButtonText` is the text for the button, `action` is a `Func<Task>` and duration is optional parameter. Default duration = 3000;

2. For advanced settings:
```csharp
    var messageOptions = new MessageOptions
    {
        Foreground = Color.Black,
        Font = Font.OfSize("Arial", 14),
        Message = "My text"
    };
    var actionOptions = new List<SnackBarActionOptions>
    {
        new SnackBarActionOptions
        {
            ForegroundColor = Color.Black,
            BackgroundColor = Color.White,
            FontFamily = Font.OfSize("Arial", 14),
            Text = "My text",
            Action = () => // null by default
            {
                Debug.WriteLine("1");
                return Task.CompletedTask;
            }
        }
    };
    var options = new SnackbarOptions
    {
        MessageOptions = messageOptions,
        Duration = 3000,
        BackgroundColor = Color.Default,
        IsRtl = false,
        Actions = actionOptions
    };
    var result = await this.DisplayToastAsync(options);
```
The result is `Boolean`. True - if snackbar is closed by user. False - if snackbar is closed by timeout.



### AvatarView

You first include the toolkit namespace:

```xaml
xmlns:xct="http://xamarin.com/schemas/2020/toolkit"
```

Then place the view in your XAML:

```xaml
<xct:AvatarView Text="DO" Size="46" Color="#FF3300" TextColor="White" />
```

Of course, `AvatarView` also supports `Source` for loading images plus a few other properties. Check it out!

![AvatarView](./images/avatar-do.png)

## Contributions welcome!

If you have one or more of these common pieces of code that you are always replicating across apps, don't hesitate to contribute! We aim to be the first NuGet package you install when creating a new Xamarin app!

Please have a look at our [contribution guide](CONTRIBUTING.md) before you get started. Also take note of the [Code of Conduct](https://dotnetfoundation.org/code-of-conduct) we adhere to.

## Community Toolkit Principles
- Principle #1: The toolkit will be kept simple.
- Principle #2: As soon as a comparable feature is available in Xamarin.Forms, it will be marked as deprecated.
- Principle #3: All features will be supported for two Xamarin.Forms release cycles or until another principle supersedes it.

## Project Structure

To structure our project, we have adopted a range of namespaces. You can find them below with a short description of what you will find where.

| Namespace | Description |
|--------------|--------------|
| Xamarin.CommunityToolkit.Core | Core objects that do not fit other namespaces and are used by multiple other components |
| Xamarin.CommunityToolkit.Behaviors | Extended behaviors for the Xamarin.Forms components |
| Xamarin.CommunityToolkit.Converters | XAML converters, used to converted your data binding data into something your XAML understands |
| Xamarin.CommunityToolkit.Effects | Effects to apply light-weight renderer changes to the Xamarin.Forms renderers |
| Xamarin.CommunityToolkit.Extensions | XAML Markup Extensions to make your XAML even more functional |
| Xamarin.CommunityToolkit.ObjectModel | Things that have to do with your models and objects. Probably handy for your MVVM needs |
| Xamarin.CommunityToolkit.UI.Layout | Layouts such as WrapLayout, etc. |
| Xamarin.CommunityToolkit.UI.Views | Controls such as TabView, etc. |
| Xamarin.CommunityToolkit.SampleApp | Sample App where you can find all of the above for reference. Learn how to use them and see how it all looks |
| Xamarin.CommunityToolkit.UnitTests | This is where our unit tests live. Please keep growing them! |

## Code of Conduct
As a part of the .NET Foundation, we have adopted the [.NET Foundation Code of Conduct](https://dotnetfoundation.org/code-of-conduct). Please familiarize yourself with that before participating with this repository. Thanks!

## .NET Foundation
This project is supported by the [.NET Foundation](https://dotnetfoundation.org).
