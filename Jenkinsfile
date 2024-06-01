pipeline {
    agent {
        docker { image 'mcr.microsoft.com/dotnet/sdk:5.0' }
    }
    stages {
        stage('Test') {
            steps {
                sh 'dotnet --version'
            }
        }
    }
}
