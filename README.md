# mzassigment
I made this little project as recrutiment assigment.

If you're developer or recruiter reviewing this solution, you may find some answers to ineviteble questions "why the hell did he do that this way?!" below :-).

## What's the purpouse of gitconnect.Model?
I wanted to decouple my "domain" model from any dependencies. I assume, that this is my bussines model, so it should represent bussines object as close as possible without having any technical code - just my domain logic. In this example there is no specific logic, but I'm assuming in real world example there would be. I also declared interfaces for my bussines objects repositries, so my model can be in charge of what methods it needs. This way I can change my implementation freely without breaking any code, that actually uses my model, as long as I'm compliant with declared interfaces. If my model changes it means that something important changed in my bussines, so it's logical, that other components should change accorddingly to provide new data. 

## Why there are tests only for methods in gitconnect.Model and not other parts?
I really feel, that unit testing suit testing actual logic. Infrastructural stuff like connecting to external resource, converting response etc. would require a lot (generally, not in this case of course) of mocks to mimic every database connector or external API and we would really test assigning values from one object to the other. In my opinion, in terms of unit testing, there is actually nothing going on in those parts of system. In bussines logic on the other hand we have all the cool stuff - some calculations, state changes etc. It sounds reasonable to test for example discount calculator algorithm in unit tests, so whenever someone would like to change code related to those calcultions, he would be sure, that he didn't brake anything. We don't need to mock so many resources either - usually it's just providing input and checking output!

## Are there any 3rd party dependecies in your project?
Yes. I used JSON.Net to deserialize API response. Honestly - I wouldn't do better job writing serialization/deserialization myself. I felt like this is a little bit outside of scope and sometimes it's just better to not reinvent the wheel.