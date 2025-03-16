# emergen-see-backend
# Intellibus Hackathon 2025
## EMERGEN-SEE

## Inspiration
Our inspiration was brought on by our own personal experiences in the healthcare system. Where we have been victims of being ignorant of the wait time for something that we think should be a relatively painless and stress free process. 

## What it does
EMERGEN-SEE gives healthcare providers the opportunity to utilize realtime transactions in combination with AI NLP, to provide be able to overSEE the queueing system for patients going through triage. EMERGEN-SEE gives SIGHT of patients, their triage assessment and their wait-times. In order to efficiently assign available Doctors to Patients in need in real-time. 

## How we built it
We utilized NEXTJS to build out the front end project. NEXT AUTH to authenticate the initial user login. Tailwind CSS for the css framework. SUPABASE as the real-time relational database to store patient and triage information. OPEN AI for the NLP. Dotnet core  8 for  the backend/API. Azure for the infrastructure. Azure SQL for the primary relational database. Azure Cosmos DB to store the Cognitive AI prompts and responses. Azure service bus to manage the message queues. Azure App Service to host the front end and back end projects respectively. Docker to containerize the application. Github actions. Azure Kubernetes to manage the cluster. Azure functions to assist in realtime transactions and deployment. 

## Challenges we ran into
Lack of power and stable internet connection for the first few hours of the hackathon. Intermittent loss of connection during git deployments and testing.  While we were able to provision the Cloud Infrastructure resources, we were not able to completely configure and deploy our solution based on our project plan. 

## Accomplishments that we're proud of
98% complete front end project.
90% complete back end project.
Provisioning of Azure resources. 

## What we learned
How to accomplish real-time transactions using SUPABASE. 
How to provision Azure resources. 


## What's next for EMERGEN-SEE
100% completion of the MVP. 
Additional features like medication suggestions. OCR for customer demographic data. AI Image Classification. Utilizing OPEN AI Whisper to assist in conducting patient triage and populating form data. 
