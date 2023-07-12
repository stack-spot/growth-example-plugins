# graphene-feign-plugin

Plugin to add OpenFeign in Java projects

## Inputs

| Field                  | Type | Description                                                                        | Default Value    |
|:-----------------------|:-----|:-----------------------------------------------------------------------------------|:-----------------|
| *project_name*         | text | Project name, usually see after package group id ex.: br.com.graphene.project_name |                  |
| *project_artifact_id*  | text | Project Artifact id                                                                |                  |
| *project_group_id*     | text | Project group id used in the project ex.: br.com.graphene                          | br.com.graphene  |
| *build_tool*           | text | Build tool used by the project                                                     |                  |
| *main_file_name*       | text | The main class file with SpringBootApplication annotation                          | Application.java |
| *generate_feign*       | bool | If YES a sample feign client code is generated in the project                      | True             |
