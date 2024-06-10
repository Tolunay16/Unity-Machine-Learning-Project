Integration of Machine Learning with Unity: A Project Framework


Abstract


This thesis outlines the process of integrating machine learning into Unity to create an interactive 3D project. The document provides a comprehensive guide to setting up the necessary software, libraries, and configurations, and offers a step-by-step methodology for developing the project.


Introduction


The primary objective of this project is to incorporate machine learning capabilities within Unity. This integration will enhance the interactivity and functionality of 3D environments. This document details the initial setup and subsequent steps required to successfully complete the project.


Part 1: Preliminary Setup


1. Unity Installation
Begin by downloading and installing the latest version of Unity. This project has been developed using Unity version 3.5.0 and is compatible with the .NET Framework 4.8.
2. Installation of ML-Agents
Incorporate the ML-Agents library into your Unity project. This library is essential for implementing machine learning functionalities within Unity.
3. Python Installation
Install Python on your system, ensuring that you use version 3.19.3. Python is a prerequisite for running the machine learning algorithms.
4. Command Line Setup
Navigate to your project's directory and open the command prompt. Execute the following commands to install the necessary packages and libraries. Ensure that the pip package manager is updated to version 23.2.1.
Refer to the image below for the specific libraries required:

![11](https://github.com/Tolunay16/Unity-Machine-Learning-Project/assets/134376655/70d77f6f-f6f0-4977-bb97-862d262eaf56)

Part 2: Project Development

Step 1: Environment Creation
Create a 3D environment where the agents will operate. This includes:
⦁	A platform for the agents to navigate.
⦁	A main agent tasked with collecting objects (balls).
⦁	The objects (balls) that the agent will collect.

![12](https://github.com/Tolunay16/Unity-Machine-Learning-Project/assets/134376655/d75e14e8-a4be-48ac-83c1-8a5091f4a8bb)

Step 2: Coding the Agent Behavior
Open a script in Unity and input the necessary code to define the agent's behavior. This script will include logic for navigating the environment and collecting objects.

![23](https://github.com/Tolunay16/Unity-Machine-Learning-Project/assets/134376655/2b87bca5-2775-44ba-9f2e-64b07c2eaca5)

Step 3: Generating Training Scenarios
Before initiating the machine learning process, generate multiple training scenarios as illustrated below. These scenarios will provide diverse data for the machine learning model to learn from.

![24](https://github.com/Tolunay16/Unity-Machine-Learning-Project/assets/134376655/0fa4d79d-d567-4db3-8715-97c7ad2e4d6d)

Step 4: Initiating Machine Learning
Start the machine learning process by entering the following command in the command prompt:

mlagents-learn --run-id=Trial1
This will begin the training process.

Step 5: Reviewing and Utilizing Results
Upon completion of the training, review the results in the results section. Integrate these results into the Assets folder of your Unity project to finalize the agent's behavior.


Conclusion
This document provides a structured approach to integrating machine learning within a Unity project. By following these steps, one can develop an interactive 3D environment with intelligent agents capable of performing specific tasks. This integration not only enhances the functionality of the project but also leverages the power of machine learning to create dynamic and adaptive behaviors.

Part 2: Environment Setup and Machine Learning Implementation

Step 1: Creating the Environment
Begin by designing a rectangular boundary around the agent's operational area. Adjust the dimensions to form a square, which will serve as the environment in which the agent operates.

![25](https://github.com/Tolunay16/Unity-Machine-Learning-Project/assets/134376655/1916bf19-4f0e-4f71-8926-2f920ae3bab0)

Step 2: Implementing Part 2 Code
Once the environment setup is complete, proceed by inputting the codes provided in Part 2 of the project. This code is essential for initiating the machine learning processes and defining the agent's behavior within the newly created environment.

![26](https://github.com/Tolunay16/Unity-Machine-Learning-Project/assets/134376655/1e55cc53-8f57-4176-8e2c-5163b5891f43)

Step 3: Starting Machine Learning
With the environment and code in place, initiate the machine learning process. This stage involves training the agent to navigate and interact within the square boundary effectively.
By following these steps, you will have successfully set up the environment and begun the machine learning phase of the project. This will enable the agent to learn and adapt its behavior based on the interactions within the defined space.

This section details the essential steps for creating the operational environment and commencing the machine learning phase. By adhering to these guidelines, the project will advance towards developing an intelligent agent capable of performing tasks within a defined 3D space.

Part 3: Enhancing the Agent and Initiating Machine Testing


Step 1: Creating and Using Prefabs

Create a folder named "Prefab" within your project directory. Prefabs allow you to apply changes universally to all instances of a particular object, ensuring consistency across your project.

![Ekran Alıntısı PNG31](https://github.com/Tolunay16/Unity-Machine-Learning-Project/assets/134376655/a6d5be5d-504f-4d63-b843-c25c8e101d9f)

Step 2: Adding Visual Enhancements

Enhance the visual appearance of your agent by adding a face. This step is crucial for improving the aesthetic appeal of your agent, making it more engaging and visually pleasing.

![35](https://github.com/Tolunay16/Unity-Machine-Learning-Project/assets/134376655/f14ae202-f9a3-426f-9429-289938d9a13e)

Step 3: Implementing Part 3 Code
Integrate the code provided in Part 3 into your project’s script. This code is essential for conducting machine testing and refining the agent’s performance.


Step 4: Starting Machine Testing


Commence the machine testing phase by running the implemented code. Monitor the results closely and halt the testing process once you achieve the desired outcomes, as illustrated in the image below.

By following these steps, you will enhance the visual aspect of your agent, ensure consistent updates through prefabs, and initiate the machine testing phase effectively. These steps are crucial for the successful completion and refinement of your project, leading to a well-developed and visually appealing intelligent agent.

Part 4: Implementing Dynamic Elements and Reward Functions

Step 1: Generating and Managing Pellets

In this phase, you will generate pellets randomly across the map. Implement functionality to remove these pellets from the map after they are collected by the agent

![gol](https://github.com/Tolunay16/Unity-Machine-Learning-Project/assets/134376655/17c40d39-e485-4ccb-9b3f-c84c50fc78b0)

Step 2: Setting Up the Reward Function


Develop a reward function that changes the environment's color based on the agent's performance. If the agent collects all the pellets, the environment should turn green, indicating success. Conversely, if the agent fails to collect all the pellets, the environment should turn red.

Step 3: Initiating Machine Learning


Once the dynamic elements and reward function are in place, begin the machine learning process. Monitor the training until you achieve the desired results, as depicted below.

![66](https://github.com/Tolunay16/Unity-Machine-Learning-Project/assets/134376655/a466fc9e-ab9b-4665-a0f8-c556ffe86bb3)

By following these instructions, you will enhance the interactivity of your environment through dynamic pellet generation and a responsive reward function. These improvements are crucial for training a more effective and adaptive agent, contributing to the overall success of your machine learning project within Unity.

Part 5: Error Handling and Machine Learning Finalization


Step 1: Implementing Error Detection Functions

In this stage, you will define functions to handle errors that occur when objects overlap or are positioned too closely together. These functions are essential for ensuring the integrity of the environment and avoiding unintended interactions.

![ppo](https://github.com/Tolunay16/Unity-Machine-Learning-Project/assets/134376655/37263d30-93ec-4699-bc70-42b01f4537a8)

Step 2: Initiating Machine Learning Tests
With the error detection functions in place, commence the machine learning tests. The goal in this phase is to ensure that the agent can operate within the environment without encountering significant errors due to overlapping or close-proximity objects.

Step 3: Monitoring and Saving Progress
You do not need to achieve a specific success rate in this part. Once you observe some level of success and the agent demonstrates the ability to function correctly with the implemented error detection, you can terminate the machine learning process. Save the project file to preserve the current state and progress.

By incorporating error detection functions and initiating machine learning tests, you ensure the robustness and reliability of your agent's interactions within the environment. This final phase is crucial for validating the overall functionality and stability of the project, paving the way for future enhancements and applications.



Part 6: Implementing a Timer and Finalizing the Project

Step 1: Adding a Timer to the Project
Introduce a timer to your project. The timer will limit the time available for the agent to collect all the pellets. If the agent fails to collect the pellets within the allotted time, the environment will turn red, indicating failure.

![ssa](https://github.com/Tolunay16/Unity-Machine-Learning-Project/assets/134376655/2d34b75c-bf65-43dd-ad97-181fd21c7072)

Step 2: Configuring the Timer
Once the timer is added, a new tab will appear in Unity’s interface. Configure the timer settings according to the project requirements. The timer will begin when the project starts, providing a set duration for the agent to complete its task.

Step 3: Integrating the Timer with Machine Learning
Incorporate the timer functionality into the machine learning model. This integration will help the agent learn to perform its task within the given time constraint.

Step 4: Training and Monitoring
Begin the machine learning process with the new timer feature. Observe the agent's performance under the time constraint. As with previous parts, a specific success rate is not necessary. Once the agent demonstrates a basic level of success in completing the task within the time limit, you can conclude the machine learning phase.

By adding a timer to your project, you introduce a critical time-based challenge for the agent, enhancing the complexity and realism of the task. This final step ensures that the agent can operate efficiently under time constraints, making the project more dynamic and engaging.


Part 7: Introducing a Hunter to the Environment

Step 1: Creating the Hunter

Create a new entity named "Hunter" in your project. The Hunter will be designed to chase the agent, adding an additional layer of challenge. The Hunter should be created and designed using the same methods as those used for the agent.

![ttr](https://github.com/Tolunay16/Unity-Machine-Learning-Project/assets/134376655/42ed2760-ed7a-48ef-b06e-d1a345ab0f96)

![sssss](https://github.com/Tolunay16/Unity-Machine-Learning-Project/assets/134376655/29f7a164-5b91-4636-8058-ceff080194b6)

Step 2: Implementing Hunter Behavior
Write the necessary scripts to define the Hunter's behavior. This script will govern how the Hunter tracks and attempts to catch the agent. Ensure that the Hunter's behavior is dynamic and poses a real challenge to the agent.

Step 3: Integrating the Hunter with the Agent
Modify the agent's script to recognize the presence of the Hunter. The agent should be able to perceive and respond to the Hunter, adjusting its behavior to avoid being caught.

Step 4: Testing the New Dynamics
Initiate machine learning tests to train the agent in the presence of the Hunter. Monitor the interactions between the agent and the Hunter, ensuring that the agent learns to evade effectively. As with previous steps, achieving a specific success rate is not required. Conclude the training once the agent demonstrates a basic level of success in evading the Hunter.

By introducing a Hunter, you add a significant challenge to the environment, requiring the agent to not only collect pellets but also avoid being caught. This final enhancement increases the complexity of the task, providing a comprehensive and engaging machine learning project.

The project has ended
















































