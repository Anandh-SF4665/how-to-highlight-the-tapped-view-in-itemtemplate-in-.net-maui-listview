using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMaui
{
    public class Behavior : Behavior<Grid>
    {
        Button Button1;
        Button Button2;
        Button Button3;

        protected override void OnAttachedTo(Grid bindable)
        {
            Button1 = bindable.FindByName<Button>("Button1");
            Button2 = bindable.FindByName<Button>("Button2");
            Button3 = bindable.FindByName<Button>("Button3");

            Button1.Clicked += OnClicked;
            Button2.Clicked += OnClicked;
            Button3.Clicked += OnClicked;

            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Grid bindable)
        {
            Button1.Clicked -= OnClicked;
            Button2.Clicked -= OnClicked;
            Button3.Clicked -= OnClicked;
            Button1 = null;
            Button2 = null;
            Button3 = null;
            base.OnDetachingFrom(bindable);
        }

        private void OnClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var bc = button.BindingContext as Contacts;

            if (button.Text == "Available")
                bc.Availability = true;
            else if (button.Text == "Away")
                bc.Availability = false;
            else
                bc.Availability = null;
        }
    }
}
