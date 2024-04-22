import React, { useState } from "react";
import { Form, Input, Button, Alert } from "antd";
import { userNameRegex, passwordRegex } from "../utils/RegexValidations";

interface RegisterProps {}

const Register: React.FC<RegisterProps> = () => {
  const [form] = Form.useForm();
  const [userError, setUserError] = useState<string>("");
  const [passwordError, setPasswordError] = useState<string>("");

  const onFinish = (values: any) => {
    console.log("Received values:", values);
  };

  const validateUsername = (rule: any, value: string, callback: any) => {
    if (userNameRegex.test(value)) {
      callback();
    } else {
      callback("Invalid username. Please use only alphanumeric characters.");
    }
  };

  const validatePassword = (rule: any, value: string, callback: any) => {
    if (passwordRegex.test(value)) {
      callback();
    } else {
      callback(
        "Invalid password. Please use at least one uppercase letter, one lowercase letter, one number, and one special character."
      );
    }
  };

  return (
    <Form
      form={form}
      layout="vertical"
      onFinish={onFinish}
      scrollToFirstError
    >
      <Form.Item
        name="username"
        label="Username"
        rules={[
          { required: true, message: "Please enter your username" },
          { validator: validateUsername },
        ]}
      >
        <Input />
      </Form.Item>
      <Form.Item
        name="password"
        label="Password"
        rules={[
          { required: true, message: "Please enter your password" },
          { validator: validatePassword },
        ]}
        hasFeedback
      >
        <Input.Password />
      </Form.Item>
      <Form.Item>
        <Button type="primary" htmlType="submit">
          Submit
        </Button>
      </Form.Item>
      {(userError || passwordError) && (
        <Alert
          message={userError || passwordError}
          type="error"
          showIcon
          style={{ marginBottom: "20px" }}
        />
      )}
    </Form>
  );
};

export default Register;
