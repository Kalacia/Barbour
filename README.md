# Barbour
 A repository for the technical stage of interviews for Barbour Logic. The scopes provided are also within this repository.

# Solution 1 - Bank account C#
**Console APP**
Unit tests
 Unit tests are currently there for the core CRUD operations into the repository. Moqed as a service.
 Fringe cases are not yet implemented
Fringe cases, Validation and error checking

# Solution 2 - Library managemednt C# dot net 8, Html and Javascript
**MVC app**
## Patterns used
Repository pattern for the users and the books.
I chose not specially implement singleton in the repositories themselves, as i used them as a AddSingleton service.
I didnt see a need to use factory patterns, as the books and users in my example where all similar. However, using factory would be useful when creating admin, poweruser and user accounts at a later date. Or if we choose to have other forms of printed media, such as comics down the line.
If i was to progress further with this, i may look at an observer pattern for the returning of books, or notifications on if a book is late.

## Use of the app
There are 4 pages in the app
```
Book management - the main space to access the books. Including delete and checkout/in
Book Add - The place to add a book.
User Management - the main space to access users. Including deletion
User Add - The place to add the user
```

## Unit testing
To use the unit testing, run the app from Visual studio. Access the test area, and run the tests. The tests are made using MOQ and in herit a test base class that sets up the MOQ services. 

## Outstanding work
The list of borrowed books is not attached to the user, rarther is kept on the book in a book history, and who has the book checked out. The functionality to search users and see what books they have checked out has not yet been implemented. But could be implemented by doing a filter on the List<Books>.FindAll(x => x.CheckedOutUser.Name == name).
There is currently a limit on having a single ISBN at a time. I should look at implementing an ID on the book that is distinct from the ISBN so that we can have multiple of the same book in the library.

