﻿using Xamarin.Forms;
using Xamarin.CommunityToolkit.Markup;

namespace Xamarin.CommunityToolkit.MarkupSample
{
    public static class Styles
    {
        static Style<Span> link;
        static Style<Button> headerButton;

        public static Style<Span> Link => link ??= new Style<Span>(
            (Span.FontSizeProperty, 14),
            (Span.TextColorProperty, Color.CornflowerBlue),
            (Span.TextDecorationsProperty, TextDecorations.Underline)
        );

        public static Style<Button> HeaderButton => headerButton ??= new Style<Button>(
            (Button.TextColorProperty, Color.CornflowerBlue),
            (Button.FontSizeProperty, 24)
        )   .BasedOn (Implicit.Buttons);

        public static class Implicit
        {
            static ResourceDictionary dictionary;
            static Style<Button> buttons;
            static Style<ImageButton> imageButtons;
            static Style<Label> labels;
            static Style<Entry> entries;

            public static ResourceDictionary Dictionary => dictionary ??= new ResourceDictionary { Labels, Entries };

            public static Style<Label> Labels => labels ??= new Style<Label>(
                (Label.TextColorProperty, Color.White)
            );

            public static Style<Button> Buttons => buttons ??= new Style<Button>(
                (Button.BackgroundColorProperty, Color.Transparent)
            );

            public static Style<ImageButton> ImageButtons => imageButtons ??= new Style<ImageButton>(
                (Button.BackgroundColorProperty, Color.Transparent)
            );

            public static Style<Entry> Entries => entries ??= new Style<Entry>(
                (Entry.TextColorProperty, Color.White),
                (Entry.BackgroundColorProperty, Color.Transparent)
            );
        }
    }
}
