I've been waiting forever, i'm glad you are finally here. #F.BrokenPanelsInspected.9
*   What? Why are you waiting for me?
     - I need you to open that door for me. #E.ShowRedDoorCamera
     * I'll try, but I'm not sure what to do. -> instructions
     * I don't think I want to do that right now #E.HideRedDoor
       Ahh okay, bye then, thanks for nothing.. -> END 	

== instructions == 
 Go to the panel, it's in the back room. #E.ShowControlPanel
     * Why can't you do that? 
       I'm too wide.. #Q.InspectThePanel
       * * Okay, I'm on it! #E.HideControlPanel 
	   Thanks! #E.HideRedDoor -> END
- -> END