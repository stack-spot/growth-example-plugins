#OFFICIAL docker-hub image eclipse-temuriun for Java {{project_java_version}}
FROM eclipse-temurin:{{project_java_version}}

RUN apt-get update && apt-get -y install curl
RUN mkdir app

{%set jar_path = "build/libs" if build_tool == "Gradle" else "target" %}
ADD {{jar_path}}/{{project_artifact_id}}-*-final.jar ./app/springApp.jar
ADD docker_entrypoint .

ENTRYPOINT ["/bin/sh", "docker_entrypoint"]