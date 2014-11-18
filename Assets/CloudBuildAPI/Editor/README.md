# A preliminary API to interact with Unity cloud build
This is a preliminary API which allows you to easily build scripts that interact with Unity Cloud build and which still compile and run locally. Locally, this API will
provide mock implementations. In the cloud, it will interact with the real thing.

To make this work, go to Unity Cloud build's "Advanced Settings" and create a new scripting define symbol named "UNITY_CLOUD" there. This will tell the scripts that they actually
run inside Unity Cloud Build. Locally, you don't need to set any scripting define symbols. 


This is currently a work in progress. Do not use it for anything productive. Once this shapes into something useful, we might release this under an appropriate open source license.