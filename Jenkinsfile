pipeline {
    agent {
        label 'docker-ssh-agent'
    }
    options {
        skipDefaultCheckout(true)
    }
    stages {
        stage('Test') {
            steps {
                checkout scm
                sh 'source /etc/.bashrc'
                sh '''#!/bin/bash
                dotnet --version
                chmod +x jenkins_test.bash
                ./jenkins_test.bash
                '''
            }
        }
    }
}
