pipeline {
    agent {
        docker { image 'mcr.microsoft.com/dotnet/sdk:8.0' }
    }
    stages {
        stage('Test') {
            steps {
                sh 'docker ps'
                sh 'whoami'
                sh 'curl --unix-socket /var/run/docker.sock http:/images/json'
                sh 'dotnet --version'
            }
        }
    }
}
