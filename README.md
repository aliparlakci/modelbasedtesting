# Model-based Testing

A model-based testing example using GraphWalker 4 on a P.I. Works product.  
Model is contained in the `ModelBasedTesting/Model.json`. You can use [AltWalker Visual Editor](https://altom.gitlab.io/altwalker/model-editor/#/visual-editor) to edit the model or create your own.

## Prequisites

- .NET Core 3.1 SDK
- Java SE Runtime Environment
- GraphWalker CLI 4.2.0  
  
Below process must be running in order for the project to run

```bash
java -jar graphwalker-cli-4.2.0.jar online --verbose --service RESTFUL
```

## Run

```bash
cd ModelBasedTesting/
dotnet run -- Model.json
```
