import { Component, OnInit } from '@angular/core';
import { IReport } from '../../models/ireport';
import { ReportService } from '../../services/data/report.service';

@Component({
  selector: 'app-policy-list',
  templateUrl: './policy-list.component.html',
  styleUrls: ['./policy-list.component.scss']
})
export class PolicyListComponent implements OnInit {

  displayedColumns: string[] = ['PolicyId', 'ProductCode', 'Product', 'Status', 'CreationDate'];
  dataSource: IReport[] = [];

  constructor(
    private reportService: ReportService,
  ) { }

  ngOnInit(): void {
    this.getPolicys();
  }

  getPolicys() {
    this.reportService.getPolicys()
      .subscribe((response: IReport[]) => {
        this.dataSource = response;
      });
  }

}
