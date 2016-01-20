# Shared Code
After getting tired of writing the same code in my projects, I decided to create a central repository for reusable code. This also gave me the chance to learn how to create DLLs. After writing a new feature, I implement unit tests to ensure that the code is stable. Future C# projects will be using and updating this library project. 

# Components
- Commands system.
  - Commands can be chained and aborted if one reports a failure.
- Event dispatching system
- File system service with [TinyJSON](https://github.com/pbhogan/TinyJSON) integration for easy object dumping and creation.
- Object pooling for easy pooling.
- Easy to use singleton class.

# TODO
- Come up with a cool name for the library.
- Update documentation.
