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
        sh 'cd Api.Test && dotnet test'
      }
    }
  }
}

