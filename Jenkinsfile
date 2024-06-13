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
                bash 'source /etc/.bashrc'
                bash ''' 
                #!/bin/bash
                dotnet --version
                chmod +x jenkins_test.bash
                ./jenkins_test.bash
                '''
            }
        }
    }
}
