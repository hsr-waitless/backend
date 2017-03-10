pipeline {
  agent { docker 'microsoft/dotnet:1.1.1-sdk' }

  stages {
    stage('install') {
      steps {
        sh 'dotnet restore'
      }
    }

    stage('build') {
      steps {
	      dir('WaitlessBackend') {
          sh 'dotnet build'
	      }
      }
    }

    stage('test') {
      steps {
        dir('Test') {
          sh 'dotnet test'
        }
      }
    }
  }
}

