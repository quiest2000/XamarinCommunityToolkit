﻿using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.Markup;
using Xamarin.CommunityToolkit.Markup.LeftToRight;
using static Xamarin.CommunityToolkit.Markup.GridRowsColumns;
using static Xamarin.CommunityToolkit.MarkupSample.SearchViewModel;
using static Xamarin.CommunityToolkit.MarkupSample.Styles;

namespace Xamarin.CommunityToolkit.MarkupSample
{
    public partial class SearchPage
    {
        void Build() => Content =
            new StackLayout { Children = {
                Header .Assign (out header),
                SearchResults,
                Footer
            }};

        StackLayout Header => new StackLayout { Children = {
            new Button { Text = "\u1438" } .Style (HeaderButton)
                        .Width (50)
                        .Bind (nameof(vm.BackCommand)),

            new Entry { Placeholder = "Search" }
                       .FillExpandHorizontal ()
                       .Invoke (entry =>
                        {
                            entry.Focused   += Search_FocusChanged;
                            entry.Unfocused += Search_FocusChanged;
                        })
                       .Bind (nameof(vm.SearchText))
        }}.Horizontal ();

        enum TweetRow { Separator, Title, Body, Actions }
        enum TweetColumn { AuthorImage, Content }

        CollectionView SearchResults => new CollectionView { ItemTemplate = new DataTemplate(() =>
            new Grid {
                RowDefinitions = Rows.Define (
                    (TweetRow.Separator, 2   ),
                    (TweetRow.Title    , Auto),
                    (TweetRow.Body     , Auto),
                    (TweetRow.Actions  , 32  )
                ),

                ColumnDefinitions = Columns.Define (
                    (TweetColumn.AuthorImage, 70  ),
                    (TweetColumn.Content    , Star)
                ),

                Children = {
                    new BoxView { BackgroundColor = Color.Gray }
                                 .Row (TweetRow.Separator) .ColumnSpan (All<TweetColumn>()) .Top() .Height (0.5),

                    RoundImage ( 53, nameof(Tweet.AuthorImage) )
                                .Row (TweetRow.Title, TweetRow.Actions) .Column (TweetColumn.AuthorImage) .CenterHorizontal () .Top () .Margins (left: 10, top: 4),

                    new Label { LineBreakMode = LineBreakMode.MiddleTruncation } .FontSize (16)
                               .Row (TweetRow.Title) .Column (TweetColumn.Content) .Margins (right: 10)
                               .Bind (nameof(Tweet.Header)),

                    new Label { } .FontSize (15)
                               .Row (TweetRow.Body) .Column (TweetColumn.Content) .Margins (right: 10)
                               .Bind (Label.FormattedTextProperty, nameof(Tweet.Body),
                                        convert: (List<TextFragment> fragments) => Format(fragments)),

                    LikeButton ( )
                                .Row (TweetRow.Actions) .Column (TweetColumn.Content) .Left () .Top () .Size (24)
                }
            })}.Background (Color.FromHex("171F2A"))
               .Bind (nameof(vm.SearchResults));

        Frame RoundImage(float size, string path) => new Frame
        {
            IsClippedToBounds = true,
            HasShadow = false,
            CornerRadius = size / 2,
            Content = new Image { } .Bind (path)
        }  .Size (size) .Padding (0);

        FormattedString Format(List<TextFragment> fragments)
        {
            var s = new FormattedString();
            fragments?.ForEach(fragment => s.Spans.Add(fragment.IsMatch ?
                new Span { Text = fragment.Text, TextColor = Color.CornflowerBlue } .FontSize (15) .Bold ()
                          .BindTapGesture (nameof(vm.OpenTwitterSearchCommand), vm) :
                new Span { Text = fragment.Text }
            ));
            return s;
        }

        Label LikeButton() => new Label { }
			.BindTapGesture (nameof(vm.LikeCommand), vm, ".")
            .Bind (nameof(Tweet.IsLikedByMe), convert: (bool like) => like ? "\u2764" : "\u2661");

        Label Footer => new Label { }
             .FontSize (14)
             .FormattedText (
				 new Span { Text = "See the " },
				 new Span { Text = "Xamarin Community Toolkit C# Markup", Style = Link }
						   .BindTapGesture(nameof(vm.OpenHelpCommand)),
				 new Span { Text = " docs" })
             .CenterHorizontal () .Margins (bottom: 6);
    }
}