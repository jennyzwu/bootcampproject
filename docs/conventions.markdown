#Project Conventions

##Convention Over Configuration

1. Convention for configuration
  * All micro configuration files are to be placed under the source/config folder
  with a .erb extension suffix after their real extension. This will allow expansion
  to occur.

2. Test Naming Convention
  * All tests for a component X will be in a file name XSpecs.cs. And that file will contain an outer class with the same name as the file, which all contexts will live under.

3. Stub Convention
  * A stub will live in a namespace named stubs under the namespace where the contract it is implementing lives.

4. Web Application Conventions
  * 1 Logical View Per Presentation Model
  * 1 Command Per Unique Request
  * 1 Model In - 1 Model Out
