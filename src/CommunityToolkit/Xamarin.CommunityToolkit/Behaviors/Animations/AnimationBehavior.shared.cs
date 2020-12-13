﻿using Xamarin.Forms;

namespace Xamarin.CommunityToolkit.Behaviors
{
	public class AnimationBehavior : EventToCommandBehavior
	{
		public static readonly BindableProperty AnimationTypeProperty =
			BindableProperty.Create(nameof(AnimationType), typeof(AnimationBase), typeof(AnimationBehavior));

		public AnimationBase AnimationType
		{
			get => (AnimationBase)GetValue(AnimationTypeProperty);
			set => SetValue(AnimationTypeProperty, value);
		}

		bool isAnimating;
		TapGestureRecognizer tapGestureRecognizer;

		protected override void OnAttachedTo(VisualElement bindable)
		{
			base.OnAttachedTo(bindable);

			if (!string.IsNullOrWhiteSpace(EventName) || !(bindable is View view))
				return;

			tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += OnTriggerHandled;
			view.GestureRecognizers.Clear();
			view.GestureRecognizers.Add(tapGestureRecognizer);
		}

		protected override void OnDetachingFrom(VisualElement bindable)
		{
			if (tapGestureRecognizer != null)
				tapGestureRecognizer.Tapped -= OnTriggerHandled;

			base.OnDetachingFrom(bindable);
		}

		protected override async void OnTriggerHandled(object sender = null, object eventArgs = null)
		{
			if (isAnimating)
				return;

			isAnimating = true;

			await AnimationType?.Animate((View)sender);

			if (Command?.CanExecute(CommandParameter) ?? false)
				Command.Execute(CommandParameter);

			isAnimating = false;

			base.OnTriggerHandled(sender, eventArgs);
		}
	}
}