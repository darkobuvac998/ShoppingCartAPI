pipeline{
    agent{
        any
    }
    stages{

      stage('Build'){
        steps{
          sh '''
          docker build -t nginx:latest
          '''
        }
      }

      stage('Test'){
        steps{
          sh '''docker run -it nignx:latest curl localhost:5000'''
        }
      } 

      stage('Package'){
        steps{

        }
      }

      stage('Deploy'){
        steps{

        }
      }
    }
}
