pipeline {
  agent { docker: 'microsoft/dotnet:runtime' }

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

