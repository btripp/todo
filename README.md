# Simple Xamarin Forms Todo App

Notes:<br/>
 - Didn't use an IoC container for brevity but did inject a dependency<br/>
 - Didn't opt for MVVM helper like prism or something to keep it simple<br/>
 - Edit and delete items using contect actions(swipe right iOS / hold down Android)<br/>
 - Used synchronous db calls for simplicity, I understand that larger data sets and longer load times<br/>
   would benefit from asynchronous calls, and would probably call for a UI loading indicator<br/>
 - Most of the TodoItems stuff is just inherited from Todo<br/>
 
 ![Screenshot 1](/screenshot1.png)
 ![Screenshot 2](/screenshot2.png)
