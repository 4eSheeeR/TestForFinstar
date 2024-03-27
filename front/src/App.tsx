import { useEffect, useState } from 'react';
import './App.css';
import { Button, Form, GetProp, Input, InputNumber, Table, TableProps, Upload, UploadFile, UploadProps } from 'antd';
import { defaultTableParams, TableParams } from './models/tableParams';
import { ItemType } from './models/ItemType';
import { ItemFilter } from './models/ItemFilter';
import { UploadOutlined } from '@ant-design/icons';

const columns: TableProps<ItemType>['columns'] = [
  {
    title: 'id',
    dataIndex: 'id',
    key: 'id',
  },
  {
    title: 'code',
    dataIndex: 'code',
    key: 'code',
  },
  {
    title: 'value',
    dataIndex: 'value',
    key: 'value',
  }
];

type FileType = Parameters<GetProp<UploadProps, 'beforeUpload'>>[0];

function App() {
  const [form] = Form.useForm<ItemFilter>();
  const [data, setData] = useState<ItemType[]>();
  const [loading, setLoading] = useState(false);
  const [tableParams, setTableParams] = useState<TableParams>(defaultTableParams);
  const [fileList, setFileList] = useState<UploadFile[]>([]);
  const [uploading, setUploading] = useState(false);

  const fetchData = async () => {
    let filter = form.getFieldsValue(true) as ItemFilter;
    const params = new URLSearchParams();

    if(!!filter.code)
    {
      params.append("code", filter.code.toString());
    }

    if(!!filter.value)
    {
      params.append("value", filter.value);
    }

    fetch('/Item?'+ params.toString(), {
      method: "GET",
      mode: "cors",
      credentials: "include",
      headers: {
        "Accept": "application/json",
        "Content-Type": "application/json"
      }})
      .then((res) =>res.json())
      .then(( results ) => {
        setData(results);
        setLoading(false);
        let count = data?.length
        setTableParams({
          ...tableParams,
          pagination: {
            ...tableParams.pagination,
            total: count,

          },
        });
      });
  }

  useEffect(() => {
    fetchData();
  }, [JSON.stringify(tableParams)]);

  const handleTableChange: TableProps['onChange'] = (pagination, filters, sorter) => {
    setTableParams({
      pagination,
      filters,
      ...sorter,
    });

    if (pagination.pageSize !== tableParams.pagination?.pageSize) {
      setData([]);
    }
  };

  const handleUpload = () => {
    const formData = new FormData();
    fileList.forEach((file) => {
      formData.append('file', file as FileType);
    });
    setUploading(true);
    fetch('/Item', {
      method: 'POST',
      body: formData,
    })
    .then(response => response.json())
    .then(result => {
    console.log('Success:', result);
    })
    .catch(error => {
    console.error('Error:', error);
    })
      .finally(() => {
        setUploading(false);
      });
  };

  const props: UploadProps = {
    onRemove: (file) => {
      const index = fileList.indexOf(file);
      const newFileList = fileList.slice();
      newFileList.splice(index, 1);
      setFileList(newFileList);
    },
    beforeUpload: (file) => {
      if(file.name.endsWith(".json"))
      {
        setFileList([file]);
      }

      return false;
    },
    fileList,
  };


  return (
    <Form
    form={form}
    name="basic"
    labelCol={{ span: 80 }}
    wrapperCol={{ span: 160 }}
    style={{ maxWidth: 500, justifyContent: 'center' }}
    autoComplete="off"
  >
    <Table columns={columns} 
        dataSource={data}
        rowKey={(record) => record.id}
        pagination={tableParams.pagination}
        loading={loading}
        onChange={handleTableChange}
        style={{marginRight:"100px", justifyContent: 'center' }}
        
        />
        
    <Form.Item<ItemFilter>
      label="Code"
      name="code"
    >
      <InputNumber />
    </Form.Item>

    <Form.Item<ItemFilter>
      label="Value"
      name="value"
    >
      <Input />
    </Form.Item>

    <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
      <Button type="primary" htmlType="submit" onClick={fetchData}>
        Применить
      </Button>
    </Form.Item>
    <Upload {...props}>
        <Button icon={<UploadOutlined />}>Select File</Button>
      </Upload>
    <Button
        type="primary"
        onClick={handleUpload}
        disabled={fileList.length === 0}
        loading={uploading}
        style={{ marginTop: 16 }}
      >
        {uploading ? 'Uploading' : 'Start Upload'}
      </Button>
  </Form>
  );
}

export default App;
