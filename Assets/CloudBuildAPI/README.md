# A preliminary API to interact with Unity cloud build
This is a preliminary API which allows you to easily build scripts that interact with Unity Cloud build and which still compile and run locally. Locally, this API will
provide mock implementations. In the cloud, it will interact with the real thing. It uses the UNITY_CLOUD_BUILD scripting define that is used inside Unity's cloud build
environment to determine whether or not is actually running in the cloud. 


This is currently a work in progress. Do not use it for anything productive. Once this shapes into something useful, we might release this under an appropriate open source license.

(C) 2014 Ancient Light Studios