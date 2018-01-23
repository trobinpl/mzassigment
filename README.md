# mzassigment
Project made as recruitment assigment

## What's the purpouse of gitconnect.Model?
I wanted to decouple my "domain" model from any dependencies. I assume, that this is my bussines model, so it should represent bussines object as close as possible without having any technical code - just my domain logic. In this example there is no specific logic, but I'm assuming in real world example there would be. I also declared interfaces for my bussines objects repositries, so my model can be in charge of what methods it needs. This way I can change my implementation freely without breaking any code, that actually uses my model, as long as I'm compliant with declared interfaces. If my model changes it means that something important changed in my bussines, so it's logical, that other components should change accorddingly to provide new data. 
