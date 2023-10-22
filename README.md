# PFM Footfall Data API

This ASP.NET Core API provides access to footfall data in hourly, daily, and weekly aggregations. The data is sourced from a CSV file containing sensor information.

## Setup and Run

1.  **Clone the Repository:**
   
    `git clone <https://github.com/zainiftikhar/PfmAssignment.git>
    cd PfmAssignment` 
    
2.  **Prerequisites:**
    
    -   [.NET Core SDK](https://dotnet.microsoft.com/download)
    -   [Visual Studio](https://visualstudio.microsoft.com) (or any preferred code editor)
3.  **Restore Dependencies:**
    
    `dotnet restore` 
    
4.  **Add CsvHelper:** CsvHelper is used for reading and processing data from the CSV file.
    
    `dotnet add package CsvHelper` 
    
5.  **Run the API:**
    
    `dotnet run` 
    
    The API will be available at `http://localhost:5000` (or `https://localhost:5001` for HTTPS) by default.
    
6.  **API Endpoints:**
    
    -   **Hourly Data:** `GET /api/pfm/hourly?dateTime={dateTime}`
    -   **Daily Data:** `GET /api/pfm/daily?dateTime={dateTime}`
    -   **Weekly Data:** `GET /api/pfm/weekly?weekNumber={weekNumber}&year={year}`

## API Usage

### Hourly Data

Retrieve hourly footfall data for a specific date and hour.

**Example Request:**

`GET /api/pfm/hourly?dateTime=2023-10-22T15:00:00` 

### Daily Data

Retrieve daily footfall data for a specific date.

**Example Request:**

`GET /api/pfm/daily?dateTime=2023-10-22` 

### Weekly Data

Retrieve weekly footfall data for a specific week and year.

**Example Request:**

`GET /api/pfm/weekly?weekNumber=42&year=2023` 

## Additional Information

-   This API reads data from a CSV file located at `Data/counts.csv`.
-   Make sure the CSV file follows the format specified in the `PfmData` class.
-   Ensure the CSV file contains valid data for accurate results.
-   The API performs basic validation on the loaded data; however, validation checks are currently commented out in the `PfmLogic` constructor. This is because there were some invalid records in the CSV file, and the validation was disabled to facilitate testing. You may uncomment and customize the validation logic in the constructor to enforce specific data constraints.
-   CsvHelper library is used for reading and processing data from the CSV file.

## Design Decisions

-   The project follows the MVC architectural pattern.
-   Hourly, daily, and weekly data processing logic is encapsulated in the `PfmLogic` class for better organization and separation of concerns.
-   Exception handling is implemented for CSV data loading and processing to provide detailed error information.
-   API endpoints are documented in the code for easy reference.
