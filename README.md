# RaceDay Platform - Part 3 (MVC Web Application)

RaceDay is a comprehensive event management and participant tracking platform built with ASP.NET Core MVC, connecting to a secure RESTful API with Azure Blob Storage integration.

## Features
- **Role-Based Authentication**: Secure login and role management (Organiser and Participant) using session state.
- **Organiser Dashboard**: Create, edit, and delete events, manage categories, view enrolments, and capture finish times.
- **Participant Portal**: Browse upcoming events with filtering, register instantly, view personal enrolments, and track race history.
- **Cloud File Storage**: Event banner images uploaded by organisers are securely stored via Azure Blob Storage through the API.

---

## Running via Docker

To run the application inside a Docker container:

1. Build the Docker image from the project root directory:
   ```bash
   docker build -t raceday-mvc .
   docker run -d -p 8080:8080 --name raceday-container raceday-mvc
   http://localhost:8080
   <ElicitationsGroup message="Choose your next step to finalize your POE:">
  <Elicitation label="Get the Organiser Dashboard .cshtml view code" query="Provide the Razor view code for the Organiser Dashboard showing event summaries and management options."/>
  <Elicitation label="Get the GitHub Actions workflow YAML file for CI/CD" query="Provide the GitHub Actions workflow YAML file that builds both projects automatically."/>
</ElicitationsGroup>
