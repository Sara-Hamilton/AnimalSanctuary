# Animal Sanctuary
##### An animal sanctuary tracker that allows vets to check information on animals.  Built with C#, ASP.NET. 

_04.25.2018_

## User Stories
* A user should be able to see a list of all animals at the sanctuary.
* A user can view an individual animals details.
* A user should be able to see a list of all veterinarians at the sanctuary.
* A user can see a veterinarians details.
* A user should be able to add a new veterinarian. 
* A user should be able to admit a new animal, linked with its veterinarian.
* A user should be able to see all animals that need medical care.
* From a list of animals, a user should be able to set an animals to the state of needing medical care
* From an animal, a user should be able to mark that it has received needed medical care.
* When an animal has been rehabilitated, and can be sent back to it's habitat, it should be removed from the database (or stored in a table of former animals?)

## Technologies Used
* HTML
* CSS
* Bootstrap
* Visual Studio
* C#
* .NET
* MySql
* MAMP

## Run the Application  

  * _Clone the github respository_
  ```
  $ git clone https://github.com/Sara-Hamilton/AnimalSanctuary
  ```

  * _Install the .NET Framework and MAMP_

    .NET Core 1.1 SDK (Software Development Kit)

    .NET runtime.

    MAMP

    See https://www.learnhowtoprogram.com/c/getting-started-with-c/installing-c for instructions and links.

* _Start the Apache and MySql Servers in MAMP_

 * _Move into the directory_
 ```
 $ cd AnimalSanctuary/AnimalSanctuary
 ```

*  _Restore project and setup the database_

  ```
  $ dotnet restore
  ```

  ```
  $ dotnet ef database update
  ```

*  _Run the program_

  ```
  $ dotnet run
  ```


## Specifications
Class Animal
	{
		AnimalId
		Name (optional?)
		Species
		Sex
		HabitatType
		MedicalEmergency (bool)
		VeterinarianId
		Veterinarian (virtual)
	}

Class Veterinarian
	{
		VeterinarianId
		Name
		Specialty
	}

## Authors
[Sara Hamilton](https://github.com/sara-hamilton)
[Johnny Mayer](https://github.com/johnnymayer)

### License

*MIT License*

Copyright (c) 2018 **_Sara Hamilton_ _Johnny Mayer_**

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.