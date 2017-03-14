pipeline {
  agent { docker 'microsoft/dotnet:1.0.4-sdk' }

  stages {
    stage('install') {
      steps {
        sh 'dotnet restore'
      }
    }

    stage('build') {
      steps {
          sh 'dotnet build'
      }
    }

    stage('test') {
      steps {
        script {
          dir('Api.Test') {
            sh 'dotnet test'
          }
        }
      }
    }

    stage('publish') {
      steps {
        script {
          dir('Api') {
            sh 'dotnet publish -c Release -o out'
          }

          def img = docker.build "no0dles/waitless-backend:${env.BUILD_TAG}"
          img.push()
        }
      }
    }
  }
}

