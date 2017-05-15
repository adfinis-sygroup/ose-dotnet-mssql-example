## Building

### Import template into project
```
oc new project dotnet-demo
oc create -f templates/aspnet-s2i-template.json
```

### Build app
```
oc new-app --template=aspnet-s2i -p GIT_URI=https://github.com/adfinis-sygroup/ose-dotnet-mssql-example
```
