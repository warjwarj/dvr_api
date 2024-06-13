pipeline {
    agent {
        label 'docker-ssh-agent'
    }
    options {
        skipDefaultCheckout(true)
    }
    stages {
        stage('Setup') {
            steps {
                checkout scm
                sh 'source /etc/.bashrc'
            }
        }
        stage('Test') {
            steps {
                sh '''#!/bin/bash
                dotnet --version
                chmod +x jenkins_test.bash
                ./jenkins_test.bash
                '''
            }
        }
    }
}
