pipeline {
    agent {
        docker { image 'mcr.microsoft.com/dotnet/sdk:5.0' }
    }
    stages {
        stage('Test') {
            steps {
                sh 'whoami'
                sh 'curl --unix-socket /var/run/docker.sock http:/images/json'
                sh 'dotnet --version'
            }
        }
    }
}
